using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.ViewModels.ProductComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class ProductCommentService(IProductCommentRepository productCommentRepository) : IProductCommentService
    {
        public Task<AddProductCommentResult> AddProductCommentAsync(AddProductCommentViewModel model)
        {
            return productCommentRepository.AddProductCommentAsync(model);
        }

        public async Task<List<ProductCommnetViewModel?>> GetAllCommentAsync(int productid)
        {
            return await productCommentRepository.GetAllCommnetAsync(productid);
        }
    }
}
