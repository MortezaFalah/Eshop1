using Domain.Eshop.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterResult>  RegisterAsync(RegisterViewModel Model);

        Task<LoginResult> LoginAsync(LoginViewModel Model);


        Task<Forgotpasswordresult> ForgotPasswordAsync(ForgotPasswordViewModel model);


        Task<Resetpasswordresult> ResetPasswordeAsync(ResetPasswordViewmodel model);
    }
}
