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
    }

   
}
