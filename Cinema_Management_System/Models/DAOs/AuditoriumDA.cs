using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cinema_Management_System.Models.DAOs
{
    public class AuditoriumDA
    {
        ConnectDataContext Connect = new ConnectDataContext();

        private static AuditoriumDA instance; 

        public static AuditoriumDA Instance
        {
            get { if (instance == null) AuditoriumDA.instance = new AuditoriumDA(); return AuditoriumDA.instance;}
            set {  AuditoriumDA.instance = value;}
        }

        private AuditoriumDA() { }

        public List<Auditorium> GetAuditoriumList()
        {
            // Danh sách phòng (có thể lấy từ DB hoặc danh sách động
            List<Auditorium> DanhSachPhong = Connect.Auditoriums.ToList();
            return DanhSachPhong;
        }
    }
}
