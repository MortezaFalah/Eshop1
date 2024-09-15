using Microsoft.AspNetCore.Mvc;

namespace Eshop1.Components
{
    public class SiteHeaderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Shared/Components/SiteHeader.cshtml");
        }
    }
}
