using Application.Eshop.Services.Impelimentation;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Shared;
using Domain.Eshop.ViewModels.Feature;
using Domain.Eshop.ViewModels.Product.ProductColor;
using Domain.Eshop.ViewModels.ProductFeature;
using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Areas.Admin.Controllers
{
    public class ProductColorController(IProductColorService productColorService):AdminBaseController
    {

        #region List
        public async Task<IActionResult> List(FilterProductColorViewModel filter)
        {

            FilterProductColorViewModel filters = await productColorService.FilterAsync(filter);

            return View(filters);
        }

        #endregion


        #region Create
        [HttpGet]
        public IActionResult Create(int productid)
        {
            return View(new CreateProductColorViewModel { ProductId = productid });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductColorViewModel model)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #endregion

            var Result = await productColorService.CreateAsync(model);
            

            switch (Result)
            {
                case CreateProductColorResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.AddProductColorSuccessfullyDone;

                    break;

                case CreateProductColorResult.ProductNotFount:
                    TempData[ErrorMessage] = ErrorMessages.ProductNotFound;

                    break;


                case CreateProductColorResult.ExistAnotherDefaultColor:
                    TempData[ErrorMessage] = ErrorMessages.ExistanotherDefaultcolor;

                    break;

                case CreateProductColorResult.DupplicatedColor:
                    TempData[ErrorMessage] = ErrorMessages.DupplicatedColor;

                    break;

            }



            return RedirectToAction(nameof(List), "ProductColor", new FilterProductFeatureViewModel { ProductId = model.ProductId });
        }
        #endregion


        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            UpdateProductColorViewModel ProductColor = await productColorService.GetForUpdateAsync(id);
            

            return View(ProductColor);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductColorViewModel model)
        {
            var Result = await productColorService.UpdateAsync(model);

            switch (Result)
            {
                case UpdateProductColorResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateProductColorSuccessfullyDone;

                    break;

                case UpdateProductColorResult.ProductNotFount:
                    TempData[ErrorMessage] = ErrorMessages.ProductNotFound;

                    break;


                case UpdateProductColorResult.ExistAnotherDefaultColor:
                    TempData[ErrorMessage] = ErrorMessages.ExistanotherDefaultcolor;

                    break;

                case UpdateProductColorResult.ColorNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ColorNotFound;

                    break;
            }

            return RedirectToAction(nameof(List), "ProductColor", new FilterProductFeatureViewModel { ProductId = model.ProductId });

        }
        #endregion


        #region Delete
        public async Task<IActionResult> Delete(int id, int productid)
        {

            var Result = await productColorService.DeleteAsync(id);

            switch (Result)
            {
                case DeleteProductColorResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.DeleteProductColorSuccessfullyDone;
                    break;

                case DeleteProductColorResult.ProductColorNotFound:
                    TempData[ErrorMessage] = ErrorMessages.ColorNotFound;
                    break;
            }
            return RedirectToAction(nameof(List), "ProductColor", new FilterProductFeatureViewModel { ProductId = productid });
        }

        #endregion


    }
}
