using Domain.Eshop.Models.Enums.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.ViewModels.ProductComment
{
    public class ProductCommentViewModelAdminSide
    {

        public int Id { get; set; }

        public int ProductId { get; set; }

        public string? UserFullName { get; set; }

        public int UserId { get; set; }

        public string? Text { get; set; }

        public string? Advantage { get; set; }

        public string?  DisAdvantage { get; set; }

        public CommentStatus Status { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
