using Application.Eshop.Services.Impelimentation;
using Application.Eshop.Services.Interfaces;
using AspNetCoreGeneratedDocument;
using Domain.Eshop.ViewModels.Product;
using Domain.Eshop.ViewModels.Product.ProductColor;
using Domain.Eshop.ViewModels.ProductComment;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eshop1.Controllers
{
    public class ProductController(IProductService productService,
        IProductColorService productColorService,
        IProductCommentService productCommentService) : SideBaseController
    {

        #region List

        [HttpGet("/Products")]
        public async Task<IActionResult> List(ClientSideFilterProductViewModel? filter)

        {
            ClientSideFilterProductViewModel models;
            if (filter.CategoryId != null)
            {
                models = await productService.GetAllProductsInCategory(filter);
            }
            else
            {
                models = await productService.FilterAsync(filter);
            }
            return View(models);
        }

        #endregion


        #region Detalis
        [HttpGet("/Products/Details/{slug}")]
        public async Task<IActionResult> Details(string slug)
        {

            var model = await productService.DetailsAsync(slug);

            return View(model);

        }
        #endregion

        #region AjaxForProductDetial

        [HttpGet("/Product/GetColorForAjax/{productcolorid}")]
        public async Task<IActionResult> GetColorForAjax(int productcolorid)
        {
            ProductColorViewModel colorViewModel = await productColorService.GetProductColorForAjaxAsync(productcolorid);
            if (colorViewModel == null)
            {
                Console.WriteLine($"No color found for ID: {productcolorid}");
                return BadRequest();
            }

            return Ok(new
            {
                price = colorViewModel.Price,
                color = colorViewModel.Color,
                colortitle = colorViewModel.ColorTitle,
                id = colorViewModel.Id
            });
        }

        #endregion

        #region ProductComment

        [HttpGet("/Product/AddProductComment/{productid}")]
        public IActionResult AddProductComment(int productid)
        {
            AddProductCommentViewModel addProductCommentViewModel = new()
            {
                    ProductId = productid,
            };
            return PartialView("/Views/Product/_AddProductComment.cshtml",addProductCommentViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductComment(AddProductCommentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    status = 110,
                    message = "لطفا تمامی اطلاعات را پر کنید"
                });
            }
            var result = await  productCommentService.AddProductCommentAsync(model);
            if(result == AddProductCommentResult.Feild)
            {
                return BadRequest(new
                {
                    status = 120,
                    message = "ثبت کامنت با خطا مواجه شد لطفا با پشتیبانی در ارتباط باشید"
                });
            }
            return Ok(new
            {
                status = 100,
                message = "نظر شما با موفقیت ثبت شد"
            });
        }




        #endregion

    }
}
