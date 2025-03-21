using Application.Eshop.Services.Impelimentation;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Models.Feature;
using Domain.Eshop.Shared;
using Domain.Eshop.ViewModels.Feature;
using Domain.Eshop.ViewModels.ProductFeature;
using Domain.Eshop.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Areas.Admin.Controllers
{
    public class FeatureController(IProductFeatureService productFeatureService,
        IFeatureService featureService) : AdminBaseController
    {

        #region List


        public async Task<IActionResult> List(int productid)
        {
            return View();
        }

        #endregion


        #region Create
        [HttpGet]
        public IActionResult Create(int productid)
        {
            return View(new CreateFeatureViewModel { ProductId =productid} );
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureViewModel model)
        {
            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            #endregion

            await featureService.CreateAsync(model);
           

            return RedirectToAction(nameof(List),"ProductFeature", new FilterProductFeatureViewModel { ProductId =model.ProductId});
        }
        #endregion



        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id , int productid)
        { 
            var feature = await featureService.GetForUpdateAsync(id);
            feature.ProductId = productid;

            return View(feature);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateFeatureViewModel model)
        {

            #region Validation

            if (!ModelState.IsValid)
            {
                return View(model);
            }
          
            #endregion
            var Result = await featureService.UpdateAsync(model);

            switch (Result)
            {
                case UpdateFeatureResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.UpdateFeatureSuccessfulydone;
                    break;

                case UpdateFeatureResult.FeatureNotFound:
                    TempData[ErrorMessage] = ErrorMessages.FeatureNotFound;

                    break;


            }

            return RedirectToAction(nameof(List), "ProductFeature", new FilterProductFeatureViewModel { ProductId = model.ProductId });
           
        }
        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int FeatureId,int productid)
        {
            var Result = await featureService.DeleteAsync(FeatureId);

            switch (Result)
            {
                case DeleteFeatureResult.Success:
                    TempData[SuccessMessage] = SuccessMessages.DeleteFeatureSuccessfulydone;
                    break;

                case DeleteFeatureResult.FeatureNotFound:
                    TempData[ErrorMessage] = ErrorMessages.FeatureNotFound;
                
                    break;


            }

            return RedirectToAction(nameof(List), "ProductFeature", new FilterProductFeatureViewModel { ProductId = productid });
        }

        #endregion 
    }
}
