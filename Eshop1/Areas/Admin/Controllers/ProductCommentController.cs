using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace Eshop1.Areas.Admin.Controllers
{
    public class ProductCommentController(IProductCommentService productCommentService) : AdminBaseController
    {
        public async Task<IActionResult> List(int productid)
        {
            if(productid < 1)
            {
                return BadRequest();
            }

            List<ProductCommentViewModelAdminSide> Lists = await productCommentService.GetAllCommentAdminSideAsync(productid);

            return View(Lists);
        }


        [HttpPost("/ProductComment/ConfirmComment/{commentid}")]
        public async Task<IActionResult> ConfirmComment(int commentid)
        {
            ProductComment? pc = await productCommentService.GetByIdAsync(commentid);

            if (pc == null)
            {
                return BadRequest(new { status = "101", message = "کامنت مورد نظر یافت نشد" });
            }

            await productCommentService.ConfirmComment(commentid);
            return Ok(new
            {
                status = 100,
                message = "کامنت مورد نظر شما تایید شد"
                
            });

        }


        [HttpPost("/ProductComment/RejectComment/{commentid}")]
        public async Task<IActionResult> RejectComment(int commentid)
        {
            ProductComment? pc = await productCommentService.GetByIdAsync(commentid);

            if (pc == null)
            {
                return BadRequest(new { status = "101", message = "کامنت مورد نظر یافت نشد" });
            }

            await productCommentService.RejectComment(commentid);
            return Ok(new
            {
                message = "کامنت مورد نظر با موفقیت رد شد",
                status = 100
            });

        }
    }
}
