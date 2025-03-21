using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.Product.ProductGallery;
using Microsoft.AspNetCore.Mvc;
using System.CodeDom;

namespace Eshop1.Areas.Admin.Controllers
{
    public class ProductGalleryController(IProductGalleryService productGalleryService) : AdminBaseController
    {


        #region List

        public async Task<IActionResult> List(FilterProductGalleryViewModel? filter)
        {

            var Galleries = await productGalleryService.FilterAsync(filter);

            return View(Galleries);
        }

        #endregion

        #region Create 
        [HttpGet]
        public async Task<IActionResult> Create(int productid)
        {
            return View(new CreateProductGalleryViewModel { ProductId = productid });
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateProductGalleryViewModel model)
        {
            #region Validation 

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var Result = await productGalleryService.CreateAsync(model);


            #endregion
            return RedirectToAction(nameof(List), new FilterProductGalleryViewModel { ProductId = model.ProductId });
        }

        #endregion




        #region Delete



        public async Task<IActionResult> DeleteImageGallery(int id, int productid)
        {

            var Result = await productGalleryService.DeleteAsync(id);


            return RedirectToAction($"{nameof(List)}", new FilterProductGalleryViewModel { ProductId = productid });
        }
        #endregion
    }
}
