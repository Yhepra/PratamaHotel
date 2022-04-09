using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Models
{
    public class RoomType
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int capacity { get; set; }
        public int numberOfRooms { get; set; }
    }
}
