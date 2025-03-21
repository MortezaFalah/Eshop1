using Domain.Eshop.Models.Common;
using Domain.Eshop.Models.Enums.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Product
{
    public class ProductComment:BaseEntity<int>
    {
        #region Property

        public int ProductId { get; set; }

        public int? UserId { get; set; }

        public string Text { get; set; }

        public string Advantage { get; set; }

        public string DisAdvantage { get; set; }

        public CommentStatus  Status { get; set; }

        #endregion

        #region Relation
        [ForeignKey(nameof(UserId))]

        public User.User? User { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        #endregion
    }
}
