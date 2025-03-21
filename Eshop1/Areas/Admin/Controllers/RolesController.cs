using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Eshop.Models.User;
using Infra.Data.Eshop.Context;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.Role;
using Application.Eshop.Services.Impelimentation;
using Domain.Eshop.Shared;
using Domain.Eshop.ViewModels.User;

namespace Eshop1.Areas.Admin.Controllers
{

    public class RolesController : AdminBaseController
    {
        private readonly EshopContext _context;


        private readonly IRoleService roleService1;

        public RolesController(EshopContext context, IRoleService roleService)
        {
            _context = context;
            roleService1 = roleService;

        }

        // GET: Admin/Roles
        [HttpGet("/Admin/Roles")]

        public async Task<IActionResult> Index()
        {

            List<Role> role = await _context.Roles.ToListAsync();
            return View("/Areas/Admin/Views/Roles/Index.cshtml", role);
        }


        // GET: Admin/Roles/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateRoleViewModel model = await roleService1.GetPermissionForCreateRoleAsync();
            return View(model);
        }

        // POST: Admin/Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateRoleViewModel role)
        {
            //role.CreateDate = DateTime.Now;
            //if (ModelState.IsValid)
            //{
            //    _context.Add(role);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

            if (!ModelState.IsValid) { return View(role); }

            var result = await roleService1.CreateRoleAndPermissionRoleAsync(role);
            switch (result)
            {
                case CreateRoleResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.SuccessfullyDoneCreateRole;
                    return RedirectToAction("Index");


                case CreateRoleResult.PermissionNotFound:
                    TempData[ErrorMessage] = ErrorMessages.PermissionNotFound;
                    return RedirectToAction(nameof(Index));


            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Admin/Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            UpdateRoleViewModel? role = await roleService1.GetForUpdateAsync(id);
            return View(role);
        }

        // POST: Admin/Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdateRoleViewModel model)
        {
            if(!ModelState.IsValid) { return View(model); }

            var result = await roleService1.UpdateRoleAndPermissionAsync(model);

            switch (result)
            {
                case UpdateRoleResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.SuccessfullyDoneUpdateRole;
                    break;


                case UpdateRoleResult.RoleNotFound:
                    TempData[ErrorMessage] = ErrorMessages.RoleNotFound;
                    return RedirectToAction(nameof(Index));


            }

            return RedirectToAction(nameof(Index));
     
        }

        // GET: Admin/Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // POST: Admin/Roles/Delete/5
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int roleid)
        {
           var result = roleService1.ConfirmDelete(roleid);
            return RedirectToAction(nameof(Index));
        }

        private bool RoleExists(int id)
        {
            return _context.Roles.Any(e => e.Id == id);
        }
    }
}
