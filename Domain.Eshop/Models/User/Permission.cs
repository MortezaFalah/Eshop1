using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.User
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Required]
        [MaxLength(80)]
        public string PermissionName { get; set; }

        [MaxLength(80)]
        public string PermissionTitle { get; set; }

        public int? ParentId { get; set; }


        [ForeignKey(nameof(ParentId))]
        public Permission? ParentPermission { get; set; }

        public ICollection<Permission>? Permissions { get; set; }

        public ICollection<PermissionRole>? PermissionRole { get; set; }
    }
}
