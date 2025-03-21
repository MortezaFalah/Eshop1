using Domain.Eshop.ViewModels.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Role
{
    public class UpdateRoleViewModel
    {

        public int RoleId { get; set; }

        [Display(Name = "عنوان نقش")]

        [MaxLength(25, ErrorMessage = "تعداد کارکتر وارد شده بیش از حد مجاز میباشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string RoleTitle { get; set; }

        public List<PermissionViewModel>? Permissions { get; set; }

        public List<int>? SelectedPermission { get; set; }

        public DateTime CreateDate { get; set; }

    }
    public enum UpdateRoleResult
    {
        Success,
        RoleNotFound,
        PermissionNotFound,

    }
}
