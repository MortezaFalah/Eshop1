using Domain.Eshop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product
{
      public class ClientSideFilterProductViewModel:BasePagingClientSide<ClientSideProductViewModel>
    {
        public string?  ProductName { get; set; }

        public string? ProductDescription { get; set; }


        public int? Price { get; set; }

        public int? CategoryId { get; set; }



    }
}
