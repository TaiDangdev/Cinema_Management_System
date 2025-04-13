using Cinema_Management_System.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.ViewModels.ShowTimeManagementVM
{
    public partial class ShowTimeViewModels
    {
        public List<MOVIE> LoadListMovie()
        {
            return MovieDA.Instance.GetMovieList();
        }

        public bool AddShowTime(int movieID, DateTime showDate, TimeSpan showTime, int auditoriumID, int ticketPrice)
        {
            try
            {
                ShowTime newShowTime = new ShowTime()
                {
                    Movie_Id = movieID,
                    Auditorium_Id = auditoriumID,
                    PerSeatTicketPrice=ticketPrice,
                    StartTime = showDate + showTime,
                    EndTime = showDate + showTime.Add(TimeSpan.FromHours(2))
                };
                return ShowTimeDA.Instance.InsertShowTime(newShowTime);
            }
            catch
            { 
                return false;
            }
        }

        public bool UpdateShowTime(int ShowTimeid,int movieID, DateTime showDate, TimeSpan showTime, int auditoriumID, int ticketPrice)
        {
            try
            {
                ShowTime newShowTime = new ShowTime()
                {
                    Id = ShowTimeid,
                    Movie_Id = movieID,
                    Auditorium_Id = auditoriumID,
                    PerSeatTicketPrice = ticketPrice,
                    StartTime = showDate + showTime,
                    EndTime = showDate + showTime.Add(TimeSpan.FromHours(2))
                };
                return ShowTimeDA.Instance.UpdateShowTime(newShowTime);
            }
            catch
            {
                return false;
            }
        }
    }
}
