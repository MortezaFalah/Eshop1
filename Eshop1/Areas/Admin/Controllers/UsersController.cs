using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Eshop.Models.User;
using Infra.Data.Eshop.Context;
using Domain.Eshop.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;
using Application.Eshop.Security;
using Domain.Eshop.ViewModels.User;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Shared;

namespace Eshop1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController
        (IRoleService roleservice,
        IUserService userservice,
        EshopContext _context): AdminBaseController
    {

        // GET: Admin/Users
        public async Task<IActionResult> Index(FilterUserViewModel filter)
        {
            return View(await _context.Users.ToListAsync());
        }


        #region CreateUser
        // GET: Admin/Users/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Roles"] = await roleservice.GetAllAsync();
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = await roleservice.GetAllAsync();
                return View(model);
            }
            #endregion


            
             var result = await userservice.CreateUserAsync(model);
            switch (result)
            {
                case CreateUserViewModelResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.SuccessfullyCreateUserAdmin;
                    return RedirectToAction("Index");


                case CreateUserViewModelResult.DupplicatedMobile:
                    TempData[DuplicatedMobile] =ErrorMessages.DuppLicatedMobileAdmin;
                    ViewData["Roles"] = await roleservice.GetAllAsync();
                    return View(model);

                case CreateUserViewModelResult.NotSelectedRoles:
                    TempData[ErrorMessage] = ErrorMessages.NotSelectedRole ;
                    ViewData["Roles"] = await roleservice.GetAllAsync();
                    return View(model);
                 

            }
            
            return RedirectToAction(nameof(Index));
            
        }
        #endregion

        #region UpdateUser
        // GET: Admin/Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int userid = id.Value;
            UpdateUserViewModel updateUserViewModel = await userservice.AdminSideGetForUpdateAsync(userid);
            if (updateUserViewModel == null)
            {
                return NotFound();
            }
      
            ViewData["Roles"] = await roleservice.GetAllAsync();
            return View(updateUserViewModel);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateUserViewModel model)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                ViewData["Roles"] = await roleservice.GetAllAsync();
                return View(model);
            }
            #endregion

            var result = await userservice.AdminSideUpdateUserAsync(model);
            switch (result)
            {
                case UpdateUserViewModelResult.Success:
                         TempData[SuccessMessage] = SuccessMessages.SuccessfullyEditUserAdmin;
                    return RedirectToAction("Index");


                case UpdateUserViewModelResult.NotFound:
                    TempData[ErrorMessage] = ErrorMessages.NotFoundUser;
                    ViewData["Roles"] = await roleservice.GetAllAsync();
                    return View(model);


                case UpdateUserViewModelResult.DupplicatedMobile:
                    TempData[DuplicatedMobile] = ErrorMessages.DuplicatedMobile;
                    ViewData["Roles"] = await roleservice.GetAllAsync();
                    return View(model);

                case UpdateUserViewModelResult.NotSelectedRoles:
                    TempData[ErrorMessage] = ErrorMessages.NotSelectedRole;
                    ViewData["Roles"] = await roleservice.GetAllAsync();
                    return View(model);


            }

            return View(model);
        }
        #endregion

        // GET: Admin/Users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id != null)
            {
                User? user = await userservice.GetUserById(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }

          
            return NotFound();
       
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
          
            bool? Deletresult = await userservice.DeleteUserForAdminAsync(id);

            switch (Deletresult)
            {
                case null:
                    return RedirectToAction("Index");


                case true:
                    TempData[SuccessMessage] = SuccessMessages.SuccessDelete;
                    return RedirectToAction(nameof(Index));


                case false:
                    TempData[ErrorMessage] = ErrorMessages.NotFoundUser;
                    return RedirectToAction(nameof(Index));


            }
          
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
