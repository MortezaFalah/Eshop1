using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Eshop1.Extentions
{
    public static class User_Extentions
    {
        public static string GetUserIP(this HttpContext context)
        {
            return context.Connection.LocalIpAddress?.ToString() ?? string.Empty;
        }
    }
}
