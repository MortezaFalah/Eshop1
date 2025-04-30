using Domain.Eshop.Models.Enums.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Extentions
{
    public static class ChangeColorCommentStatus
    {
        public static string GetStatusClass(this CommentStatus status)
        {
            return status switch
            {
                CommentStatus.Rejected => "col-red",
                CommentStatus.Pending => "col-purple",
                CommentStatus.Confirmed => "col-green",
                _ => ""
            };
        }
    }
}
