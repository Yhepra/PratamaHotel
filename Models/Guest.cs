using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Models
{
    public class Guest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string idCardNumber { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
    }
}
