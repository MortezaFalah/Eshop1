using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Common
{
    public class BaseEntity<T>
    {
        [Key]

        public T Id { get; set; }

        [Display(Name = "تاریخ ایجاد")]
     
        public DateTime CreateDate { get; set; }
    }
}
