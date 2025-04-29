using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DTOs
{
    public class SeatForShowTimesDTO
    {
        public int IdSeatForShowTimes { get; set; }

        public int Seat_Id { get; set; }

        public int showTimeId { get; set; }
        public int? condition { get; set; }
        public string location { get; set; }
        public int Auditorium_Id { get; set; }
    }
}
