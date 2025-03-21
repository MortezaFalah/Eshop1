using Domain.Eshop.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.User
{
    public class Role:BaseEntity<int>
    {

        [Display(Name ="عنوان نقش")]

        [MaxLength(25, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RoleTitle { get; set; }


       public List<UserRole>? RoleRoles { get; set; }

        public ICollection<PermissionRole>? PermissionRole { get; set; }
    }
}
