using Domain.Eshop.Models.Common;
using Domain.Eshop.Models.Enums.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Eshop.Models.Order
{
    public class Order:BaseEntity<int>
    {
        #region Properties
        public int UserId { get; set; }

        public bool IsFinally { get; set; }

        public OrderType Type { get; set; }


        #endregion

        #region Relation

        public ICollection<OrderDetail>? OrderDetails { get; set; }

        [ForeignKey(nameof(UserId))]
        public Domain.Eshop.Models.User.User? User { get; set; }

        #endregion
    }
}
