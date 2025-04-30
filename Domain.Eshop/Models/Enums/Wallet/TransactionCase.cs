using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Enums.Wallet
{
    public enum TransactionCase
    {
        [Display(Name ="شارژ کیف پول")]
        ChargeWallet,

        [Display(Name = "خرید محصول")]
        BuyProduct
    }
}
