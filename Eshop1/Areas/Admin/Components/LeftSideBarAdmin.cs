using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Areas.Admin.Components
{
    public class LeftSideBarAdmin : ViewComponent
    {
        
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Areas/Admin/Views/Shared/Components/LeftSideBarAdmin.cshtml");
        }
    }
}
