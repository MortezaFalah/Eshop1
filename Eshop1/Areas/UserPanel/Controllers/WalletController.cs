using Application.Eshop.Extentions;
using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.Wallet;
using Eshop1.Extentions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Eshop1.Areas.UserPanel.Controllers
{
    public class WalletController(IWalletService walletService) : UserPanelBase
    {
        public async Task<IActionResult> List(FilterWalletViewModel model)
        {

            int id = User.GetUserId();
            model.UserId = id;
            var filter = await walletService.FilterWalletAsync(model);
            ViewData["inventory"] = await walletService.DepositWallet(id) -  await walletService.CreditorWallet(id);
            return View(filter);
        }

        [HttpPost]
        public async Task<IActionResult> ChargeWallet(int price)
        {
            if (price < 1000)
            {
                return Ok(
                    new
                    {
                        status = 101,
                        message = "مبلغ وارد شده معتبر نمیباشد"
                    });
            }
            int userid = User.GetUserId();
            string userIp = HttpContext.GetUserIP();
            CreateWalletViewModel model = new CreateWalletViewModel()
            {
                Price = price,
                userid = userid,
                UserIp = userIp
            };
            bool result = await walletService.ChargeWalletAsync(model);
            return Ok(
                new
                {
                    status = 100,
                    url = "https://www.digikala.com" //ForExample //ToDo
                }
                );
        }

     
    }
}
