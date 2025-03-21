using Application.Eshop.Senders.Interface;
using Application.Eshop.Senders.Service;
using Application.Eshop.Services.Impelimentation;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Infra.Data.Eshop.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.IOC.Eshop.Container
{
    public static class IocContainer
    {
        public static void RegisterServices(this IServiceCollection service)
        {
            #region Services

            service.AddScoped<IUserService,UserService>();

            service.AddScoped<IAccountService, AccountService>();

            service.AddScoped<ISmsSender,SmsSender>();

            service.AddScoped<IRoleService, RoleService>();

            service.AddScoped<IProductCategoryService, ProductCategoryService>();

            service.AddScoped<IProductService, ProductService>();

            service.AddScoped<IProductGalleryService, ProductGalleryService>();

            service.AddScoped<IFeatureService, FeatureService>();

            service.AddScoped<IProductFeatureService, ProductFeatureService>();

            service.AddScoped<IProductColorService, ProductColorService>();

            service.AddScoped<IOrderService, OrderService>();

            service.AddScoped<IProductCommentService, ProductCommentService>();

            #endregion




            #region Repository

            service.AddScoped<IUserRipository, UserRipository>();
            service.AddScoped<IRoleRepository, RoleRepository>();
            service.AddScoped<IUserRoleRepository, UserRoleRepository>();
            service.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IProductGalleryRepository, ProductGalleryRepository>();
            service.AddScoped<IFeatureRepository, FeatureRepository>();
            service.AddScoped<IProductFeatureRepository, ProductFeatureRepository>();
            service.AddScoped<IProductColorRepository, ProductColorRepository>();     
            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            #endregion
        }
    }
}
