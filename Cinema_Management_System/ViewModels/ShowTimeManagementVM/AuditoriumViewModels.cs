using Cinema_Management_System.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModels.ShowTimeManagementVM
{
    public class AuditoriumViewModels
    {
        public List<Auditorium> Auditoriums { get; set; }
        public AuditoriumViewModels()
        {
            LoadAuditoriums();
        }

        private void LoadAuditoriums()
        {
            Auditoriums = AuditoriumDA.Instance.GetAuditoriumList();
        }
    }
}
