﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Feature
{
    public class UpdateFeatureViewModel
    {

        public int FeatureId { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "عنوان ویژگی")]
        [MaxLength(150, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Title { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name = "مقدار ویژگی")]
        [MaxLength(350, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        public string Value { get; set; }

        [Required(ErrorMessage = "لطفا {0} را مشخص کنید")]
        [Display(Name = "اولویت")]
        public int Order { get; set; }

        [Required]
        public int ProductId { get; set; }
    }

    public enum UpdateFeatureResult
    {
        Success,
        FeatureNotFound,
        Error
    }
}

