using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product.ClientSideProductDetail
{
    public class DetailProdcutCategoryViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int? ParentId { get; set; }


    }
}
