using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Role
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }

        [Display(Name = "عنوان نقش")]

        [MaxLength(25, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RoleTitle { get; set; }

        [Display(Name ="تاریخ ایجاد")]
        public DateTime CreateDate { get; set; }

    }
}
