using Domain.Eshop.Models.Common;
using Domain.Eshop.Models.Enums.Product;
using Domain.Eshop.Models.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Models.Product
{
    public class CommentReaction:BaseEntity<int>
    {
        public int CommentId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public CommentReactionType  Status { get; set; }



        
        public ProductComment? ProductComment { get; set; }

        
        public Domain.Eshop.Models.User.User? User { get; set; }

       
        public Product? Product { get; set; }


    }
}
