using Application.Eshop.Services.Interfaces;
using Domain.Eshop.ViewModels.ContactUs;
using Eshop1.Extentions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eshop1.Controllers
{
    public class ContactUsController(IContactUsService contactUsService) : SideBaseController
    {
        [HttpGet("/ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost("/ContactUs")]
        public async Task<IActionResult> ContactUs(CreateContactUsViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            model.Ip = HttpContext.GetUserIP();
            var res = await contactUsService.AddAsync(model);
            if (res == true)
            {
                TempData["SuccessMessage"] = "سپاسگزاریم! فرم شما با موفقیت ارسال شد. تیم ما در اسرع وقت به شما پاسخ خواهد داد";
            }
            return RedirectToAction(nameof(ContactUs));
        }
    }
}
