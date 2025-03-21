using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.User
{
    public class FilterUserViewModel
    {
        public string? Param { get; set; }

        public int PageId { get; set; } = 1;
    }
}
