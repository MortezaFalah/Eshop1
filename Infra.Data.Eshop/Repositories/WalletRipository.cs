using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.Enums.Wallet;
using Domain.Eshop.Models.Wallet;
using Domain.Eshop.ViewModels.Wallet;
using Infra.Data.Eshop.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class WalletRipository(EshopContext context) : IWalletRipository
    {

        #region General

        public Task<int> CreditorWallet(int userid)
          => context.Wallet.Where(t => t.Userid == userid && t.Type == TransactionType.Creditor && t.Payed).SumAsync(r => r.Price);

        public Task<int> DepositWallet(int userid)
        => context.Wallet.Where(t => t.Userid == userid && t.Type == TransactionType.Deposit && t.Payed).SumAsync(r => r.Price);

        #endregion

        #region UserPanel
        public async Task<bool> ChargeWallet(CreateWalletViewModel model)
        {

            Wallet wallet = new Wallet()
            {
                CreateDate = DateTime.Now,
                Description = "شارژ کیف پول",
                Case = TransactionCase.ChargeWallet,
                Type = TransactionType.Deposit,
                Payed = false,
                Price = model.Price,
                Userid = model.userid,
                IP = model.UserIp
            };
            await AddWalletAsync(wallet);
            return true;
        }



        public async Task<FilterWalletViewModel> FilterAsync(FilterWalletViewModel model)
        {
            var Query = context.Wallet.Where(R => R.Userid == model.UserId).AsQueryable();

            switch (model.Type)
            {
                case TransactionType.Creditor:
                    Query = Query.Where(t => t.Type == TransactionType.Creditor);
                    break;

                case TransactionType.Deposit:
                    Query = Query.Where(t => t.Type == TransactionType.Deposit);
                    break;

            }

            switch (model.Case)
            {
                case TransactionCase.BuyProduct:
                    Query = Query.Where(t => t.Case == TransactionCase.BuyProduct);
                    break;

                case TransactionCase.ChargeWallet:
                    Query = Query.Where(t => t.Case == TransactionCase.ChargeWallet);
                    break;

            }

            await model.Paging(Query.Select(f => new UserPanelWalletViewModel()
            {
                Id = f.Id,
                Case = f.Case,
                CreateDate = f.CreateDate,
                Description = f.Description,
                Price = f.Price,
                Type = f.Type,
                IsPayed = f.Payed,
                RefId = f.RefId,
            }));
            return model;

        }


        #endregion


        #region ForAdminPanel
        public async Task<FilterWalletAdminViewModel> FilterForAdminAsync(FilterWalletAdminViewModel model)
        {
            var Query = context.Wallet.AsQueryable();

            switch (model.Type)
            {
                case TransactionType.Creditor:
                    Query = Query.Where(t => t.Type == TransactionType.Creditor);
                    break;

                case TransactionType.Deposit:
                    Query = Query.Where(t => t.Type == TransactionType.Deposit);
                    break;

            }

            switch (model.Case)
            {
                case TransactionCase.BuyProduct:
                    Query = Query.Where(t => t.Case == TransactionCase.BuyProduct);
                    break;

                case TransactionCase.ChargeWallet:
                    Query = Query.Where(t => t.Case == TransactionCase.ChargeWallet);
                    break;

            }
            if (!string.IsNullOrEmpty(model.Mobile))
            {
                Query = Query.Include(r => r.User).Where(w => w.User != null && w.User.Mobile == model.Mobile);
            }
            if (model.IsPayed == true) { Query = Query.Where(e => e.Payed); }
            if (model.IsPayed == false) { Query = Query.Where(e => !e.Payed); }


            await model.Paging(Query.Select(f => new AdminWalletViewModel()
            {
                Id = f.Id,
                Case = f.Case,
                CreateDate = f.CreateDate,
                Description = f.Description,
                Price = f.Price,
                Type = f.Type,
                IsPayed = f.Payed,
                RefId = f.RefId,
                UserEmail = f.User.email,
            }));
            return model;

        }

        public async Task AdminChargeWallet(AdminChargeWalletViewModel model)
        {
            Wallet wallet = new()
            {
                Case = model.Case,
                CreateDate = DateTime.Now,
                Description = model.Description,
                Price = model.Price,
                Type = model.Type,
                IP = null,
                Payed = true,
                RefId = model.RefId,
                Userid = model.Userid,
            };
            await AddWalletAsync(wallet);
        }

        public async Task AddWalletAsync(Wallet wallet)
        {
            await context.AddAsync(wallet);
            await context.SaveChangesAsync();
        }

        #endregion
    }
}
