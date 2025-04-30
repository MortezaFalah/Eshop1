using Application.Eshop.Extentions.User;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductComment;
using Infra.Data.Eshop.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class ProductCommentService(IProductCommentRepository productCommentRepository
        ,IUserRipository userRipository) : IProductCommentService
    {
        public Task<AddProductCommentResult> AddProductCommentAsync(AddProductCommentViewModel model)
        {
            return productCommentRepository.AddProductCommentAsync(model);
        }

        public async Task ConfirmComment(int commentid)
        {
           await productCommentRepository.ConfirmComment(commentid);
        }

        public async Task<List<ProductCommentViewModelAdminSide>> GetAllCommentAdminSideAsync(int productid)
        {

            List<ProductComment>? PComment = await productCommentRepository.GetAllCommentAsyncAdminSide(productid);
            

            List<ProductCommentViewModelAdminSide> comments = new List<ProductCommentViewModelAdminSide>();
            foreach (var item in PComment)
            {
                Domain.Eshop.Models.User.User? User = await  userRipository.GetUserById(item.UserId ?? 0);
                comments.Add(new ProductCommentViewModelAdminSide()
                {
                    ProductId = productid,
                    Text = item.Text,
                    Advantage = item.Advantage,
                    DisAdvantage = item.DisAdvantage,
                    Id = item.Id,
                    Status = item.Status,
                    UserId = item.UserId ?? 0,
                    CreateDate = item.CreateDate,
                    UserFullName = User.GetFullname(),
                });

            }

            return comments;
            
        }

        public async Task<List<ProductCommnetViewModel?>> GetAllCommentAsync(int productid)
        {
            return await productCommentRepository.GetAllCommnetAsync(productid);
        }

        public async Task<ProductComment?> GetByIdAsync(int commentid)
        {
            return await productCommentRepository.GetByIdAsync(commentid);
        }

        public async Task RejectComment(int commentid)
        {
            await productCommentRepository.RejectComment(commentid);
        }
    }
}
