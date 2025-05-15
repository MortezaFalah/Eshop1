using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.ContactUs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eshop1.Areas.Admin.Controllers
{
    public class ContactUsController(IContactUsService contactUsService) : AdminBaseController
    {
        [HttpGet("Admin/ContactUs")]
        public async Task<IActionResult> List(FilterContactUsAdminViewModel model)
        {
            var res = await contactUsService.FilterAsync(model);
            return View(res);
        }


        public IActionResult Details(int contactusid) 
        {
            return View();
        }

        public IActionResult Answer()
        {
            return View();
        }
    }
}
