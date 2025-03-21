using Domain.Eshop.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product.ProductGallery
{
    public class FilterProductGalleryViewModel : BasePaging<ProductGalleryViewModel>
    {

        [Display(Name = "عنوان عکس")]
        public string? Title { get; set; }

        public int? ProductId { get; set; }


        public IFormFile? NewAvatar { get; set; }
    }
}
