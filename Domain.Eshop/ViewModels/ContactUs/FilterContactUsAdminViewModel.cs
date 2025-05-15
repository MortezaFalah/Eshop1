using Domain.Eshop.ViewModels.Common;
using Domain.Eshop.ViewModels.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ContactUs
{
    public class FilterContactUsAdminViewModel : BasePaging<AdminContactUsViewModel>
    {
        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public string? FilterAllString { get; set; }

        public StatusOfAnswer? Answerstatus { get; set; }
    }


    public enum StatusOfAnswer
    {
        [Display(Name = "پاسخ داده شده")]
        Answered,
        [Display(Name = "منتظر پاسخ")]
        Pending,
    }
}
