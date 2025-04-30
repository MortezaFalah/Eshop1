using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Enums.Wallet
{
    public enum TransactionType
    {
        [Display(Name ="واریز")]
        Deposit,

        [Display(Name = "برداشت")]
        Creditor
    }
}
