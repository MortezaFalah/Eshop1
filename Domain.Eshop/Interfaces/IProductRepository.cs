using Domain.Eshop.Models.Product;
using Domain.Eshop.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Eshop.ViewModels.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using Domain.Eshop.ViewModels.Product.ClientSideProductDetail;

namespace Domain.Eshop.Interfaces
{
    public interface IProductRepository
    {

        Task InsertAsync(Product product);


        Task SaveAsync();

        void Update(Product product);

        Task<Product?> GetByIdAsync(int id);
        
        
        Task<FilterProductViewModel> FilterAsync(FilterProductViewModel model);
        
        
        Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel model);


        Task<Product> GetBySlugAsync(string slug);

        Task<List<DetailProdcutCategoryViewModel>>? GetAllCategoryAsync(int categoryid);


        Task<ClientSideFilterProductViewModel> GetAllProductsCategory(ClientSideFilterProductViewModel model);

    }
}
