using Application.Eshop.Extentions;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.Order;
using Domain.Eshop.ViewModels.OrderDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Eshop1.Controllers
{
    [Authorize]
    public class OrderController(IOrderService orderService) : SideBaseController
    {

        #region List

        [HttpGet("/Card")]
        public async Task<IActionResult> List()
        {
           
            int id = User.GetUserId();
            OrderViewModel orderViewModel = await orderService.GetCartItemsAsync(id) ?? new OrderViewModel { OrderDetails = new List<OrderDetailViewModel>() }; ;
            return View(orderViewModel);
        }

        #endregion
    }
}
