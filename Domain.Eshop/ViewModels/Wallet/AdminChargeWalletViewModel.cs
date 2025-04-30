using Domain.Eshop.Models.Enums.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Wallet
{
    public class AdminChargeWalletViewModel
    {
        public int Userid { get; set; }

        public int Price { get; set; }

        public TransactionType Type { get; set; }

        public TransactionCase Case { get; set; }


        public string? RefId { get; set; }


        public string? Description { get; set; }
    }
}
