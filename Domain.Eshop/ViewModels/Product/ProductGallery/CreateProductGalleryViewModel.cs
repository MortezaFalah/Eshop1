using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Product.ProductGallery
{
    public class CreateProductGalleryViewModel
    {

        [Display(Name = "عنوان عکس")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Title { get; set; }

       
       

        public IFormFile FileImage { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductId { get; set; }

    }

    public enum CreateProductGalleryResult
    {
        success,
         Error, 
         NotSelectedPhoto
    }
}
