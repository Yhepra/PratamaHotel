using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Models
{
    public class CheckIn
    {
        [Key]
        public string idCheckin { get; set; }
        public Reservation reservation { get; set; }
        public string roomNumber { get; set; }
        public string notes { get; set; }
        public int additionalCosts { get; set; } 
    }
}
