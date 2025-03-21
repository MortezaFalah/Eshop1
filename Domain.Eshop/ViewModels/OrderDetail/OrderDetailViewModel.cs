using Domain.Eshop.ViewModels.Product.ProductColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.OrderDetail
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }

        public int ProducId { get; set; }

        public string ProductTitle { get; set; }

        public string? Warranty { get; set; }

        public string ProductAvatar { get; set; }

        public List<ProductColorViewModel>?  ProductColor { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }
    }
}
