using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Models
{
    public class Room
    {
        [Key]
        public string idRoom { get; set; }
        public RoomType roomType { get; set; }
    }

    public class RoomForm {
        public string idRoom { get; set; }
        public string roomType { get; set; }
    }
}
