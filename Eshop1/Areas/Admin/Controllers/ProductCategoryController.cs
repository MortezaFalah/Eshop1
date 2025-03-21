using Application.Eshop.Services.Impelimentation;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Shared;
using Domain.Eshop.ViewModels.ProductCategory;
using Domain.Eshop.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshop1.Areas.Admin.Controllers
{
    public class ProductCategoryController
        (IProductCategoryService productcategoryservice) : AdminBaseController
    {
        public async Task<IActionResult> List(FilterProductCategoryViewModel? filter)
        {
            var model = await productcategoryservice.FilterAsync(filter);


            return View(model);
        }


        #region CreateProductCategory
        // GET: Admin/Users/Create
        public async Task<IActionResult> Create()
        {
            ViewData["PanentCategory"] = await productcategoryservice.GetAllParents();
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductCategoryViewModel model)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                //ViewData["Roles"] = await roleservice.GetAllAsync();
                return View(model);
            }
            #endregion

            var result = await productcategoryservice.CreateAsync(model);
            switch (result)
            {
                case CreateProductCategoryResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.CreateProductCategorySuccessfulydone;
                    return RedirectToAction(nameof(List));
            }

            ViewData["PanentCategory"] = await productcategoryservice.GetAllParents();
            return View(model);

        }
        #endregion


        #region Update
        //#region UpdateUser
        // GET: Admin/Users/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UpdateProductCategoryViewModel UpdateProductCategory = await productcategoryservice.GetProductCategoryForUpdate(id);
            if (UpdateProductCategory == null)
            {
                return NotFound();
            }

            ViewData["PanentCategory"] = await productcategoryservice.GetAllParents();
            return View(UpdateProductCategory);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductCategoryViewModel model)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                ViewData["PanentCategory"] = await productcategoryservice.GetAllParents();
                return View(model);
            }
            #endregion

            var result = await productcategoryservice.UpdateAsync(model);
            switch (result)
            {
                case UpdateProductCategoryResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateProductCategorySuccessfulydone;
                    return RedirectToAction(nameof(List));


                case UpdateProductCategoryResult.ProductCategoryNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductCategoryNotFound;
                    ViewData["PanentCategory"] = await productcategoryservice.GetAllParents();
                    return View(model);


            }
            ViewData["PanentCategory"] = await productcategoryservice.GetAllParents();
            return View(model);
        }

        #endregion

        public async Task<IActionResult> Delete(int id)
        {

            Enum result = await productcategoryservice.DeleteAsync(id);
            switch (result)
            {
                case DeleteProductCategoryResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.DeleteProductCategorySuccessfulydone;
                    break;


                case DeleteProductCategoryResult.ProductCategoryNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductCategoryNotFound;
                    break;



            }
            return RedirectToAction(nameof(List));
        }

    }
}
