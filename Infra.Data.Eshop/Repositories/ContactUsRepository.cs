using Domain.Eshop.Interfaces;
using Domain.Eshop.Models.ContactUs;
using Domain.Eshop.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Eshop.Repositories
{
    public class ContactUsRepository(Context.EshopContext _context) : IContactUsRepository
    {
        public async Task<bool> AddAsync(CreateContactUsViewModel model)
        {
            ContactUs contactUs = new ContactUs()
            {
                Fullname = model.FullName,
                CreateDate = DateTime.Now,
                Description = model.Description,
                Email = model.Email,
                Mobile = model.Mobile,
                Title = model.Title,
                Ip = model.Ip ?? string.Empty,

            };

            await _context.AddAsync(contactUs);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
