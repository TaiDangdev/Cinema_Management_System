using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DTOs
{
    public class ShowTimeDTO
    {

        public int ShowTimeID { get; set; }

        public int Movie_id { get; set; }

        public string MovieTitle { get; set; }
        public byte[] MovieImage { get; set; }
        public string AuditoriumName { get; set; }

        public int Auditorium_Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int SeatTicketPrice { get; set; }
        public bool Status
        {
            get
            {
                DateTime now = DateTime.Now;
                if (EndTime.HasValue)
                {
                    return now < EndTime.Value; // true nếu phim vẫn đang chiếu hoặc chưa chiếu
                }
                return now < StartTime; // Nếu không có EndTime, chỉ kiểm tra StartTime
            }
        }

        

    }
}
