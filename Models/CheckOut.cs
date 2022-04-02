using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Models
{
    public class CheckOut
    {
        [Key]
        public string idCheckOut { get; set; }
        public DateTime date { get; set; }
        public Reservation reservation { get; set; }
        public int fine { get; set; }
    }
}
