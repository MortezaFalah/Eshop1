using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.Permission
{
    public class PermissionViewModel
    {

        public int PermissionId { get; set; }

        [Display(Name ="عنوان دسترسی")]
        public string PermissionTitle { get; set; }

        public int? ParentId { get; set; }

    }
}
