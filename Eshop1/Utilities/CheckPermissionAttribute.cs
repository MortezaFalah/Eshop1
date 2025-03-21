using Application.Eshop.Extentions;
using Application.Eshop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Shared;
using NuGet.Protocol.Core.Types;
using System.Security;

namespace Eshop1.Utilities
{
    public class CheckPermissionAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly string permissiontitle;

        public CheckPermissionAttribute(string permissiontitle)
        {
            this.permissiontitle = permissiontitle;
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            IUserService service = (context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService)!;

            int currentuserid = context.HttpContext.User.GetUserId();

            if (service.CheckUserHasPermission(currentuserid, permissiontitle))
            {
                return Task.CompletedTask;
            }


            //context.Result = new ForbidResult();
            context.Result = new RedirectToActionResult("Login", "Account", null);
            return Task.CompletedTask;

        }
    }
}
