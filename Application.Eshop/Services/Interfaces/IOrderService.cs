﻿using Domain.Eshop.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderViewModel>? GetCartItemsAsync(int userid);

    }
}
