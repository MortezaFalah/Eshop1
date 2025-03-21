using Application.Eshop.Services.Impelimentation;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Shared;
using Domain.Eshop.ViewModels.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using Eshop1.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Areas.Admin.Controllers
{
    public class ProductController(IProductService productService, IProductCategoryService productcategoryservice) : AdminBaseController
    {
        #region List
        [CheckPermission("Products")]
        public async Task<IActionResult> List(FilterProductViewModel? model)
        {

            var Products = await productService.FilterAsync(model);
            return View(Products);
        }

        #endregion


        #region CreateProduct
        // GET: Admin/Users/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Category"] = await productcategoryservice.GetAllChildAsync();
            return View();
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                ViewData["Category"] = await productcategoryservice.GetAllChildAsync();
                return View(model);
            }
            #endregion

            var result = await productService.CreateAsync(model);
            switch (result)
            {
                case CreateProductResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.CreateProductSuccessfulydone;
                    return RedirectToAction(nameof(List));
            }

            ViewData["Category"] = await productcategoryservice.GetAllChildAsync();
            return View(model);

        }
        #endregion


        #region Update

        public async Task<IActionResult> Update(int id)
        {
            UpdateProductViewModel product = await productService.GetProductForUpdate(id);

            ViewData["Category"] = await productcategoryservice.GetAllChildAsync();
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            #region Validation
            if (!ModelState.IsValid)
            {
                ViewData["Category"] = await productcategoryservice.GetAllChildAsync();
                return View(model);
            }
            #endregion

            var result = await productService.UpdateAsync(model);
            switch (result)
            {
                case UpdateProductResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateProductSuccessfulydone;
                    return RedirectToAction(nameof(List),"Product", new { area = "Admin" });


                case UpdateProductResult.ProductNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductNotFound;
                    ViewData["Category"] = await productcategoryservice.GetAllChildAsync();
                    return View(model);


            }
            ViewData["Category"] = await productcategoryservice.GetAllChildAsync();
            return View(model);
        }

        #endregion


        #region Delete 

        public async Task<IActionResult> Delete(int id)
        {

            Enum result = await productService.DeleteAsync(id);
            switch (result)
            {
                case DeleteProductResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.DeleteProductSuccessfulydone;
                    break;


                case DeleteProductResult.ProductNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ProductNotFound;
                    break;



            }
            return RedirectToAction(nameof(List));
        }

        #endregion


    }
}
