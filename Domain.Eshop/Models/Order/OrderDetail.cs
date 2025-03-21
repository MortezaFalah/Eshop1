using Domain.Eshop.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;



namespace Domain.Eshop.Models.Order
{
    public class OrderDetail : BaseEntity<int>
    {
        #region Properties

        public int Orderid { get; set; }

        public int ProducId { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }


        #endregion

        #region Relation
        [ForeignKey(nameof(Orderid))]
        public Order? Order { get; set; }

        [ForeignKey(nameof(ProducId))]
        public Domain.Eshop.Models.Product.Product? Product { get; set; }

        public ICollection<ProdcutColorOrderDetail>? ProdcutColorOrderDetails { get; set; }

        #endregion
    }
}
