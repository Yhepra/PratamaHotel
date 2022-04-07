using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PratamaHotel.Helper
{
    public class General
    {
        public static List<Claim> CreateKlaim(string id, string role)
        {
            return new List<Claim>
            {
                new Claim("Id", id),
                new Claim("Role", role) 
            };
        }
    }
}
