using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.Wallet;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eshop1.Areas.Admin.Controllers
{
    public class WalletController(IWalletService walletService) : AdminBaseController
    {
        public async Task<IActionResult> List(FilterWalletAdminViewModel model)
        {
            var Wallet = await walletService.FilterForAdminAsync(model);

            return View(Wallet);
        }



        [HttpGet]
        public IActionResult ChargeWalletAdmin(int userid)
        {
            return PartialView("/Areas/Admin/Views/Wallet/_ChargeWalletAdmin.cshtml",
                new AdminChargeWalletViewModel() { Userid = userid });
        }

        [HttpPost]
        public async Task<IActionResult> ChargeWalletAdmin(AdminChargeWalletViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return Ok(new 
                {
                    status=110,
                    message= "مقادیر مورد نظر را وارد کنید!"
                });
            }

            await walletService.AdminChargeWallet(model);



            return Ok(new
            {
                status = 100,
                message = "عملیات با موفقیت انجام شد"
            });
        }

    }

}
