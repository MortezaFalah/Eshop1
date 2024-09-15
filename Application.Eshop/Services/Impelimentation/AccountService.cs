using Application.Eshop.Generators;
using Application.Eshop.Security;
using Application.Eshop.Senders.Interface;
using Application.Eshop.Senders.Service;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Enums;
using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.User;
using Domain.Eshop.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class AccountService
        (IUserRipository _userrepository,
        ISmsSender _smssender) : IAccountService
    {
        public async Task<Forgotpasswordresult> ForgotPasswordAsync(ForgotPasswordViewModel model)
        {
            User? user = await _userrepository.GetByMobileAsync(model.Mobile);
            if (user == null) { return Forgotpasswordresult.MobileNotFound; }
            if (user.Status == UserStatus.Ban) { return Forgotpasswordresult.UserBan; }

            string confirmcode = CodeGenerator.RndGenerate();
            try
            {
                string message = $"کد تایید شما {confirmcode} میباشد لطفا این کد را در اختیار دیگران قرار ندهید!";
                string result = await _smssender.SendSmsAsync(model.Mobile, message, false);
               
                user.ConfirmCode = int.Parse(confirmcode);
                _userrepository.UpdateUser(user);
                await _userrepository.SaveAsync();
                return Forgotpasswordresult.Success;
            }
            catch
            {
                return Forgotpasswordresult.Error;
            }

        }

        public async Task<LoginResult> LoginAsync(LoginViewModel Model)
        {
            string Hashpass = PasswordHelper.EncodePasswordMd5(Model.Password);
            User user = await _userrepository.GetByIdMobilePassword(Model.Mobile, Hashpass);
            if (user == null) return LoginResult.NotFound;
            if (user.Status == UserStatus.Ban) return LoginResult.IsBan;
            return LoginResult.Successfully;
        }

        public async Task<RegisterResult> RegisterAsync(RegisterViewModel Model)
        {

            if (await _userrepository.ExistMobileAsync(Model.Mobile))
            {
                return RegisterResult.DuplicatedMobile;
            }

            string HashPassword = PasswordHelper.EncodePasswordMd5(Model.Password);
            User user = new()
            {
                CreateDate = DateTime.Now,
                Password = HashPassword,
                Status = UserStatus.Active,
                Firstname = null,
                Lastname = null,
                email = null,
                Mobile = Model.Mobile,

            };
            await _userrepository.InsertAsync(user);
            await _userrepository.SaveAsync();

            return RegisterResult.SuccessRegister;

        }

        public async Task<Resetpasswordresult> ResetPasswordeAsync(ResetPasswordViewmodel model)
        {
            User? user = await _userrepository.GetByMobileandConfirmCode(model.Mobile, model.ConfirmCode);
            if (user == null) return Resetpasswordresult.NotFound;
            if (user.Status == UserStatus.Ban) return Resetpasswordresult.error;
             string hashpass = PasswordHelper.EncodePasswordMd5(model.Password);
            user.Password = hashpass;
            user.ConfirmCode = null;
            _userrepository.UpdateUser(user);
            await _userrepository.SaveAsync();

            return Resetpasswordresult.success;
        }
    }
}
