using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Controllers
{
    public class SideBaseController : Controller
    {
        protected string ErrorMessage = "ErrorMessage";
        protected string SuccessMessage = "SuccessMessage";
        protected string DuplicatedMobile = "DuplicatedMobile";
        protected string InfoMessage = "InfoMessage";


        protected string NotFound = "NotFound";
        protected string UserIsBan = "UserIsBan";
        protected string SuccessfullyLogin = "SuccessfullyLogin";

    }
}
