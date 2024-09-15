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
            #endregion




            #region Repository

            service.AddScoped<IUserRipository, UserRipository>();
            #endregion
        }
    }
}
