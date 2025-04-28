using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DTOs
{
    public class BillSeatsForShowTimesDTO
    {
        public int Id { get; set; }
        public int quantity { get; set; }
        public int MovieId { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateTimeShowTime { get; set; }
        public string MovieName { get; set; }
        public string AuditoriumName { get; set; }
        public string NameStaff { get; set; }
        public int? Discount { get; set; }
        public int TotalPrice { get; set; }
        public int ticketPrice { get; set; }

    }



}
