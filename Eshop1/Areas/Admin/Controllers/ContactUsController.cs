using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Areas.Admin.Controllers
{
    public class ContactUsController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
