using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Areas.UserPanel.Controllers
{
    public class HomeController : UserPanelBase
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
