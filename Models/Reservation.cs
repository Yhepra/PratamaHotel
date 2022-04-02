using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Models
{
    public class Reservation
    {
        [Key]
        public string code { get; set; }
        public DateTime orderDate { get; set; }
        public Guest guest { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; }
        public int numberOfRoom { get; set; }
        public int billEstimate { get; set; }
    }
}
