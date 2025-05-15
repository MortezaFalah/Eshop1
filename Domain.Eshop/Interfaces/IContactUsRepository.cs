using Domain.Eshop.ViewModels.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IContactUsRepository
    {
        Task<bool> AddAsync(CreateContactUsViewModel model);


        Task<FilterContactUsAdminViewModel> FilterAsync(FilterContactUsAdminViewModel model);

    }
}
