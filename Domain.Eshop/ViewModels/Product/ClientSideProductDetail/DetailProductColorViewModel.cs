using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product.ClientSideProductDetail
{
    public class DetailProductColorViewModel
    {
        public int ColorId { get; set; }

        public string Color { get; set; }

        public int? Price { get; set; }

        public string ColorTitle { get; set; }

        public bool IsDefault { get; set; }

        public int Quantity { get; set; }
    }
}
