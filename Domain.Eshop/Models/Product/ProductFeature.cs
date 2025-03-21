using Domain.Eshop.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Product
{
    public class ProductFeature:BaseEntity<int>
    {
 
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int FeatureId { get; set; }

        [Required]
        public bool IsDelete { get; set; }

        #region Relations

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }


        [ForeignKey(nameof(FeatureId))]
        public Feature.Feature? Feature { get; set; }

        #endregion
    }
}
