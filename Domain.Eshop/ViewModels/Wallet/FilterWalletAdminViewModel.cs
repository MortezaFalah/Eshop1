using Domain.Eshop.Models.Enums.Wallet;
using Domain.Eshop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Wallet
{
    public class FilterWalletAdminViewModel:BasePaging<AdminWalletViewModel>
    {

        public string? Mobile { get; set; }  // برای فیلتر با ایمیل
        public TransactionType? Type { get; set; }
        public TransactionCase? Case { get; set; }
        public bool? IsPayed { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? RefId { get; set; }
    }
}
