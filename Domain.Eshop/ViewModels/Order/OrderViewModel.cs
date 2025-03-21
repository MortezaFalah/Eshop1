using Domain.Eshop.Models.Enums.Order;
using Domain.Eshop.ViewModels.OrderDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Order
{
    public class OrderViewModel
    {

        public int UserId { get; set; }

        public OrderType type { get; set; }

        public bool IsFinally { get; set; }

        public int OrderNumber { get; set; }

        public DateTime CreateDate { get; set; }

        public List<OrderDetailViewModel>? OrderDetails { get; set; }
    }
}
