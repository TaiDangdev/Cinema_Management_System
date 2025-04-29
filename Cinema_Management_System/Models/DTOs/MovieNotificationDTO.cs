using System;
namespace Cinema_Management_System.Models.DTOs
{
    public class MovieNotificationDTO
    {
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? RemainingShowtimes { get; set; }
        public string WarningMessage { get; set; }
    }
}
