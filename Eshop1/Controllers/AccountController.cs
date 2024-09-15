using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Models.User;
using Domain.Eshop.Shared;
using Domain.Eshop.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;

namespace Eshop1.Controllers
{
    public class AccountController
        (IAccountService accountService,
          IUserService userService
         ) : SideBaseController
    {

        #region Actions


        #region Register
        [HttpGet("/Register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost("/Register")]
        public async Task<IActionResult> Register(RegisterViewModel Model)
        {
            #region Validation
            if (!ModelState.IsValid)
                return View(Model);
            #endregion

            RegisterResult result = await accountService.RegisterAsync(Model);

            switch (result)
            {
                case RegisterResult.DuplicatedMobile:
                    TempData[DuplicatedMobile] = ErrorMessages.DuplicatedMobile;
                    break;

                case RegisterResult.SuccessRegister:
                    TempData[SuccessMessage] = SuccessMessages.SuccessRegister;
                    return RedirectToAction("Index", "Home", new { Area = "UserPanel" });


            }


            return View(Model);

        }




        #endregion


        #region Login
        [HttpGet("/Login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost("/Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            #region Validation
            if (!ModelState.IsValid) return View(model);

            #endregion


            LoginResult result = await accountService.LoginAsync(model);

            switch (result)
            {
                case LoginResult.NotFound:
                    TempData[NotFound] = ErrorMessages.NotFounds;
                    return RedirectToAction(nameof(Register));

                case LoginResult.WrongItem:
                    TempData[UserIsBan] = ErrorMessages.UserBan;
                    return RedirectToAction(nameof(Register));

                case LoginResult.Successfully:
                    //Login
                    User? user = await userService.GetByMobileAsync(model.Mobile);
                    if (user == null) { return RedirectToAction(nameof(Register)); }
                    var Claim = new List<Claim>()
                    {
                        new Claim(ClaimTypes.MobilePhone, model.Mobile),
                        
                        new Claim(ClaimTypes.NameIdentifier , user.Id.ToString())
                    };
                    var ClaimsIdentity = new ClaimsIdentity(Claim, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimprincipal = new ClaimsPrincipal(ClaimsIdentity);
                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = true,
                    };
                    await HttpContext.SignInAsync(claimprincipal, properties);
                    TempData[SuccessfullyLogin] = SuccessMessages.SuccessLogin;
                    return RedirectToAction("Index", "Home", new { Area = "UserPanel" });
            }


            return View(model);







        }
        #endregion


        #region LogOut
        [HttpGet("/Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View(nameof(Login));
        }

        #endregion

        #region ForgotPassword 
        [HttpGet("/forgot-password")]
        public async Task<IActionResult> ForgotPassword()
        {

            return View();
        }

        [HttpPost("/forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            #region Validation
            if (!ModelState.IsValid)
                return View(model);
            #endregion


            Forgotpasswordresult result = await accountService.ForgotPasswordAsync(model);


            switch (result)
            {
                case Forgotpasswordresult.Success:
                    TempData[SuccessMessage] = SuccessMessages.ForgotpasswordSuccessfulydone;
                    TempData["mobile"] = model.Mobile;
                    return RedirectToAction(nameof(ResetPassword));

                case Forgotpasswordresult.UserBan:
                    TempData[UserIsBan] = ErrorMessages.UserBan;
                    return RedirectToAction("/");

                case Forgotpasswordresult.MobileNotFound:
                    TempData[NotFound] = ErrorMessages.NotFounds;
                    return RedirectToAction(nameof(ForgotPassword));

            }

            return View();
        }


        #endregion


        #region ResetPassword

        [HttpGet("/Reset-Password")]
        public async Task<IActionResult> ResetPassword()
        {
            await HttpContext.SignOutAsync();
            return View();
        }


        [HttpPost("/Reset-Password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewmodel model)
        {
           
            #region Validation
            if (!ModelState.IsValid)
                return View(model);
            #endregion
            model.Mobile = TempData["mobile"]?.ToString();
            Resetpasswordresult result = await accountService.ResetPasswordeAsync(model);

            switch (result)
            {
                case Resetpasswordresult.NotFound:
                    TempData[NotFound] = ErrorMessages.NotFounds;
                    return RedirectToAction(nameof(ForgotPassword));

                case Resetpasswordresult.error:
                    TempData[ErrorMessage]=ErrorMessages.UserBan;
                    return RedirectToAction("/");

                case Resetpasswordresult.success:
                    TempData[SuccessMessage]= SuccessMessages.ResetpasswordSuccessfulydone;
                    return RedirectToAction(nameof(Login));
            }

            return View(model);
        }

        #endregion

        #endregion
    }
}