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
    }
}
