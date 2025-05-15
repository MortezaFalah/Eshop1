using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ContactUs
{
    public class AdminContactUsViewModel
    {
      
        public string? Title { get; set; }

    
        public string? FullName { get; set; }

       
        public string? Email { get; set; }

      
        public string? Mobile { get; set; }

        public int? AnswerUserid { get; set; }

        public DateTime CreateDate { get; set; }


    }
}
