using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.User
{
    public class PermissionRole
    {
        #region Properties

        [Key]
        public int Id { get; set; }

        public int PermissionId { get; set; }

        public int RoleId { get; set; }
        #endregion


        #region navigationProperty

        public Permission? Permission { get; set; }

        public Role? Role { get; set; }

        #endregion
    }
}
