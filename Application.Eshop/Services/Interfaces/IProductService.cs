using Domain.Eshop.Models.Product;
using Domain.Eshop.ViewModels.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Eshop.ViewModels.Product;
using Domain.Eshop.ViewModels.Product.ClientSideProductDetail;

namespace Application.Eshop.Services.Interfaces
{
    public interface IProductService
    {


        Task<CreateProductResult> CreateAsync(CreateProductViewModel model);


        Task<UpdateProductViewModel> GetProductForUpdate(int id);


        Task<FilterProductViewModel> FilterAsync(FilterProductViewModel? model);



        Task<UpdateProductResult> UpdateAsync(UpdateProductViewModel model);


        Task<DeleteProductResult> DeleteAsync(int id);


        Task<ClientSideFilterProductViewModel> FilterAsync(ClientSideFilterProductViewModel? model);

        Task<ClientSideProductDetailViewModel> DetailsAsync(string slug);

        Task<ClientSideFilterProductViewModel> GetAllProductsInCategory(ClientSideFilterProductViewModel model);

    }
}
