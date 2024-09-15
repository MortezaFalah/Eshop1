using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Eshop.Extentions
{
    public static class GetIdFromAuthenticaion
    {
        public static int GetUserId(this ClaimsPrincipal claimprincipal)
        {
            string? userid = claimprincipal.Claims.FirstOrDefault(f => f.Type == ClaimTypes.NameIdentifier).Value;
            if (userid == null) { return default(int); }

            return int.Parse(userid);
        }
    }
}
