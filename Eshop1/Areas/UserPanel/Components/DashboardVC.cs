using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Areas.UserPanel.Components
{
    public class DashboardVC:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Areas/UserPanel/Views/Shared/Components/DashboardVC.cshtml");
        }   
    }
}
