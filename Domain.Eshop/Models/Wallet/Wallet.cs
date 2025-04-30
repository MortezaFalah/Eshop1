using Domain.Eshop.Models.Common;
using Domain.Eshop.Models.Enums.Wallet;
using Domain.Eshop.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Wallet
{
    public class Wallet:BaseEntity<int>
    {

        #region Properties

        public int Userid { get; set; }

        public int Price { get; set; }

        public int? OrderId { get; set; }

        public TransactionType Type { get; set; }

        public TransactionCase Case { get; set; }

        public bool Payed { get; set; }

        public string? IP { get; set; }

        public string? RefId { get; set; }

        public string? Description { get; set; }

        #endregion


        #region NavigationProperty

        public Domain.Eshop.Models.User.User? User { get; set; }


        public Order.Order? Order { get; set; }

        #endregion
    }
}
