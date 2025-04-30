using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.ViewModels.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class WalletService(IWalletRipository walletRipository) : IWalletService
    {
        public async Task AdminChargeWallet(AdminChargeWalletViewModel model)
        {
             await walletRipository.AdminChargeWallet(model);
        }

        public async Task<bool> ChargeWalletAsync(CreateWalletViewModel wallet)
        {
            return await walletRipository.ChargeWallet(wallet);
        }

        public async Task<int> CreditorWallet(int userid)
         => await walletRipository.CreditorWallet(userid);

        public async Task<int> DepositWallet(int userid)
        => await walletRipository.DepositWallet(userid);

        public async Task<FilterWalletAdminViewModel> FilterForAdminAsync(FilterWalletAdminViewModel model)
        {
            return await walletRipository.FilterForAdminAsync(model);
        }

        public Task<FilterWalletViewModel> FilterWalletAsync(FilterWalletViewModel wallet)
        {
            return walletRipository.FilterAsync(wallet);
        }


    }
}
