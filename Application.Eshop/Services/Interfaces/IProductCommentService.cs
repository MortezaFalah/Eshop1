using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IProductCommentService
    {
        Task<List<ProductCommnetViewModel?>> GetAllCommentAsync(int productid);

        Task<AddProductCommentResult> AddProductCommentAsync(AddProductCommentViewModel model);

        Task<List<ProductCommentViewModelAdminSide>> GetAllCommentAdminSideAsync(int productid);

        Task<ProductComment?> GetByIdAsync(int commentid);

        Task ConfirmComment(int commentid);

        Task RejectComment(int commentid);
    }
}
