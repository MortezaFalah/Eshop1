using Application.Eshop.Services.Interfaces;
using Domain.Eshop.Interfaces;
using Domain.Eshop.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Impelimentation
{
    public class ContactUsService(IContactUsRepository contactUsRepository) :IContactUsService
    {
        public async Task<bool> AddAsync(CreateContactUsViewModel model)
        {
            return await contactUsRepository.AddAsync(model);
        }

        public async Task<FilterContactUsAdminViewModel> FilterAsync(FilterContactUsAdminViewModel model)
        {
           return await contactUsRepository.FilterAsync(model);
        }
    }
}
