using Application.Eshop.Extentions;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Shared;
using Domain.Eshop.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Eshop1.Areas.UserPanel.Controllers
{
    public class UserController(IUserService userservice) : UserPanelBase
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/UserPanel/EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            EditProfileViewModel? user = await userservice.GetUserforEditProfile(User.GetUserId());
           
            return View(user);
        }

        [HttpPost("/UserPanel/EditProfile")]
        public async Task<IActionResult> EditProfile(EditProfileViewModel model)
        {
            #region validation
            if (!ModelState.IsValid) { return View(model); }
            #endregion

            model.UserId = User.GetUserId();

            EditProfileResult result = await userservice.UpdateUserAsync(model);
            switch (result)
            {
                case EditProfileResult.error:
                    TempData[ErrorMessage] = ErrorMessages.OperationFeild;
                    return RedirectToAction(nameof(Index),"",new{area="UserPanel"});

                case EditProfileResult.success:
                    TempData[SuccessMessage] = SuccessMessages.SuccessEditProfile;
                    return RedirectToAction(nameof(Index),"", new { area = "UserPanel" });

                case EditProfileResult.NotFound:
                    TempData[NotFound] = ErrorMessages.NotFounds;
                    return View();
            }

            return View(model);
        }
    }
}
