using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModels.ShowTimeManagementVM
{
    public partial class ShowTimeViewModels
    {
        public List<ShowTimeDTO>ShowTimeList { get; set; }

        public ShowTimeViewModels() {
            this.LoadShowTimes();
        }

         public void LoadShowTimes()
        {
            ShowTimeList = ShowTimeDA.Instance.getShowTimeList();
        }


        // loc suat chieu theo phong
        public List<ShowTimeDTO> FilterShowTimeByAuditorium(int id)
        {
            return ShowTimeDA.Instance.filterShowTimeByAuditorium(id);
        }

        // loc suat chieu theo phim



        // loc phim theo phong
        public List<ShowTimeDTO>FilterMovieByAuditorium(int id)
        {
            return ShowTimeDA.Instance.FilterMovieByAuditorium(id);
        }

    }
}
