using Domain.Eshop.Models.Product;



namespace Domain.Eshop.Models.Order
{
    public class ProdcutColorOrderDetail
    {
        #region Property

        public int Id { get; set; }

        public int OrderDetailId { get; set; }

        public int ProductColorId { get; set; }

        #endregion

        #region Relation

        public ICollection<OrderDetail>? OrderDetails { get; set; }

        public ICollection<ProductColor>? ProductColors { get; set; }

        #endregion
    }
}
