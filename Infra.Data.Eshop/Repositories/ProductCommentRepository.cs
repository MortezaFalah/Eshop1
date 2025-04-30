using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Enums.Product;
using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductComment;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infra.Data.Eshop.Repositories
{
    public class ProductCommentRepository(EshopContext _context) : IProductCommentRepository
    {

        public async Task<List<ProductCommnetViewModel>>? GetAllCommnetAsync(int productid)
        {
            return await _context.ProductComment.Where(r => r.ProductId == productid && r.Status == CommentStatus.Confirmed)
                .Include(t => t.User)
                .Select(g => new ProductCommnetViewModel
                {
                    ProductId = g.ProductId,
                    Status = g.Status,
                    UserFullname = "g.User.GetFullname",
                    Advantage = g.Advantage,
                    DisAdvantage = g.DisAdvantage,
                    Text = g.Text,
                }).ToListAsync();


            #region FillProductIdevennullcomment

            // var comments = await _context.ProductComment.Where(r => r.ProductId == productid && r.Status == CommentStatus.Confirmed)
            //.Include(t => t.User)
            //.Select(g => new ProductCommnetViewModel
            //{
            //    ProductId = g.ProductId,
            //    Status = g.Status,
            //    UserFullname = "g.User.GetFullname",
            //    Advantage = g.Advantage,
            //    DisAdvantage = g.DisAdvantage,
            //    Text = g.Text,
            //}).ToListAsync();

            // if (comments == null || comments.Count == 0)
            // {
            //     return new List<ProductCommnetViewModel>()
            //     {
            //         new ProductCommnetViewModel(){
            //         ProductId = productid,
            //     }
            //     };


            // }


            // return comments;

            #endregion

        }


        public async Task<AddProductCommentResult> AddProductCommentAsync(AddProductCommentViewModel viewModel)
        {
            if (!await IsExistProduct(viewModel.ProductId))
            {
                return AddProductCommentResult.Feild;
            }
            ProductComment productComment = new()
            {
                Advantage = viewModel.Advantages,
                DisAdvantage = viewModel.DisAdvantages,
                Text = viewModel.Text,
                CreateDate = DateTime.Now,
                ProductId = viewModel.ProductId,
                Status = CommentStatus.Pending,
                UserId = viewModel.Userid

            };

            try
            {
                await _context.AddAsync(productComment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"خطای دیتابیس: {ex.Message}");
                return AddProductCommentResult.Feild;
            }
            //await _context.AddAsync(productComment);
            //await _context.SaveChangesAsync();
            return AddProductCommentResult.Success;

        }

        public async Task<bool> IsExistProduct(int productid)
          => await _context.Product.AnyAsync(e => e.Id == productid);



        public void SaveChangeAsync()
             => _context.SaveChangesAsync();

        #region AdminSide
        public async Task<List<ProductComment>> GetAllCommentAsyncAdminSide(int productid)
        {
            List<ProductComment>? PComment = await _context.ProductComment.Where(r => r.ProductId == productid).ToListAsync();

            return PComment;


        }

        public async Task<ProductComment?> GetByIdAsync(int commentid)
             => await _context.ProductComment.FirstOrDefaultAsync(r => r.Id == commentid);

        public async Task ConfirmComment(int commentid)
        {
            ProductComment? pc = await GetByIdAsync(commentid);
            pc.Status = CommentStatus.Confirmed;
            SaveChangeAsync();
        }

        public async Task RejectComment(int commentid)
        {
            ProductComment? pc = await GetByIdAsync(commentid);
            pc.Status = CommentStatus.Rejected;
            SaveChangeAsync();
        }



        #endregion
    }
}
