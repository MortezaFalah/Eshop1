using Domain.Eshop.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Eshop.Models.User;

namespace Domain.Eshop.Models.ContactUs
{
    public class ContactUs:BaseEntity<int>
    {

        #region Properties
        public string Title { get; set; } = string.Empty;

        public string Fullname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? Answer { get; set; }

        public int? AnswerUserId { get; set; }

        public string Ip { get; set; }

        #endregion

        #region Relation 

        public User.User? AnswerUser { get; set; }

        #endregion

    }
}
