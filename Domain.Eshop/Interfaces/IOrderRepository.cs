using Domain.Eshop.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Eshop.Interfaces
{
    public interface IOrderRepository
    {

        Task<OrderViewModel> GetUserCartItemsAsync(int userid);

    }
}
