using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Models
{
    public class Employee
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Role role { get; set; }
        public string image { get; set; }
    }
}
