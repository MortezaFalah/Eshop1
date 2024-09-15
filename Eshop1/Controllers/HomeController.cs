using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace Eshop1.Controllers;

public class HomeController : Controller
{
    
    
    public IActionResult Index()
    {
        return View();
    }


    [HttpGet("/Contact-Us")]
    public IActionResult ContactUs()
    {
        return View();
    }
    
}
