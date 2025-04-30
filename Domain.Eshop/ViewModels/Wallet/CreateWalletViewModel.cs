using Domain.Eshop.Models.Enums.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Wallet
{
    public class CreateWalletViewModel
    {
        public int userid { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
        public string? UserIp { get; set; }

    }
}
