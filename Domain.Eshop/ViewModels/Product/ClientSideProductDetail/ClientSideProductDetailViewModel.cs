using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product.ClientSideProductDetail
{
    public class ClientSideProductDetailViewModel
    {

        public int ProductId { get; set; }

        public int Price { get; set; }

        public string AvatarName { get; set; }

        public string Title { get; set; }


        public string Description { get; set; }

        public int Quantity { get; set; }

        public string? Review { get; set; }

        public string? warning { get; set; }

        public bool FreeShiping { get; set; }

        public string? warranty { get; set; }

        public int CategoryId { get; set; }


        public List<DetailProdcutCategoryViewModel>? Categories { get; set; }

        public List<DetailProductGalleryViewModel>? ProductGalleries { get; set; }

        public List<DetailProductColorViewModel>? ProductColors { get; set; }

        public List<DetailProductFeatureViewModel>? ProductFeatures { get; set; }

       
    }
}
