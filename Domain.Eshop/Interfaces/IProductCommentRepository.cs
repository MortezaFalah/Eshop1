using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IProductCommentRepository
    {
        Task<List<ProductCommnetViewModel>>? GetAllCommnetAsync(int productid);

        Task<AddProductCommentResult> AddProductCommentAsync(AddProductCommentViewModel viewModel);

        Task<bool> IsExistProduct(int productid);

        void SaveChangeAsync();


        #region ForAdminSide

        Task<List<ProductComment>> GetAllCommentAsyncAdminSide(int productid);

        Task<ProductComment?> GetByIdAsync(int commentid);

        Task ConfirmComment(int commentid);

        Task RejectComment(int commentid);

        #endregion
    }


}
