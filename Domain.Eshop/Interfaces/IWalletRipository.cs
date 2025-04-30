using Domain.Eshop.Models.Wallet;
using Domain.Eshop.ViewModels.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IWalletRipository
    {
        Task<FilterWalletViewModel> FilterAsync(FilterWalletViewModel model);

        Task<FilterWalletAdminViewModel> FilterForAdminAsync(FilterWalletAdminViewModel model);

        Task<bool> ChargeWallet(CreateWalletViewModel model);

        Task<int> DepositWallet(int userid);

        Task<int> CreditorWallet(int userid);

        Task AdminChargeWallet(AdminChargeWalletViewModel model);

        Task AddWalletAsync(Wallet wallet);

    }
}
