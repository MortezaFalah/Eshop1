using Application.Eshop.Services.Impelimentation;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.ProductFeature;
using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Areas.Admin.Controllers
{
    public class ProductFeatureController(IProductFeatureService productFeatureService):AdminBaseController
    {

        #region List
        public async Task<IActionResult> List(FilterProductFeatureViewModel filter)
        {
            var model = await productFeatureService.FilterAsync(filter);
            return View(model);
        }

        #endregion



       // #region Create


       // [HttpGet]
       //public  IActionResult Create()
       // {
       //     return View();
       // }
       // [HttpPost]
       // public IActionResult Create(CreateProductFeatureViewModel model)
       // {
          
       //     return View();
       // }
       // #endregion

       // #region Delete

       // public IActionResult Delete(int id)
       // {
       //     return View();
       // }

       // #endregion
    }
}
