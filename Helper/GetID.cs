using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PratamaHotel.Helper
{
    public static class GetID
    {
        public static string GetName(this ClaimsPrincipal emp)
        {
            if (emp.Identity.IsAuthenticated)
            {
                return emp.Claims.FirstOrDefault(
                    x=>
                    x.Type == "Name"
                    )?
                    .Value ?? string.Empty;
            }
            return string.Empty;
        }
    }
}
