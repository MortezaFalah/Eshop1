using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Enums.Product
{
    public enum CommentStatus
    {
        [Display(Name ="در انتظار تایید")]
        Pending,
        [Display(Name = "رد شده")]
        Rejected,
        [Display(Name = "تایید شده")]
        Confirmed
    }
}
