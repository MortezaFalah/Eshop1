using Domain.Eshop.ViewModels.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IWalletService
    {

        #region UserPanel

        Task<FilterWalletViewModel> FilterWalletAsync(FilterWalletViewModel wallet);


        Task<bool> ChargeWalletAsync(CreateWalletViewModel wallet);

        #endregion


        Task<FilterWalletAdminViewModel> FilterForAdminAsync(FilterWalletAdminViewModel model);


        Task<int> DepositWallet(int userid);

        Task<int> CreditorWallet(int userid);

        Task AdminChargeWallet(AdminChargeWalletViewModel model);

    }
}
