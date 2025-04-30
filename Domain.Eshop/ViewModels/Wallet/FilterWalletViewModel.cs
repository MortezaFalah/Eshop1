using Domain.Eshop.Models.Enums.Wallet;
using Domain.Eshop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Eshop.ViewModels.Wallet
{
    public class FilterWalletViewModel:BasePaging<UserPanelWalletViewModel>
    {

        public int UserId { get; set; }

        public TransactionType? Type { get; set; }

        public TransactionCase? Case { get; set; }
    }
}
