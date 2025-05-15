using Domain.Eshop.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IContactUsService
    {
        Task<bool> AddAsync(CreateContactUsViewModel model);

        Task<FilterContactUsAdminViewModel> FilterAsync(FilterContactUsAdminViewModel model);
    }
}
