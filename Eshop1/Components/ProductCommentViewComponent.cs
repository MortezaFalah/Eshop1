using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.ProductComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Core.Types;

namespace Eshop1.Components
{
    public class ProductCommentViewComponent(IProductCommentService productCommentService):ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int productid)
        {

            //List<ProductCommnetViewModel?> Comments = await productCommentService.GetAllCommentAsync(productid);
            //Comments.Add(new ProductCommnetViewModel() { ProductId = productid });
            ViewData["productId"] = productid;
            return View("/Views/Shared/Components/ProductComment.cshtml",await productCommentService.GetAllCommentAsync(productid));

        }
    }
}
