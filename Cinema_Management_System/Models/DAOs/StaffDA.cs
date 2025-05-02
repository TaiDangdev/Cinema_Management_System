using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DAOs
{
    public class StaffDA
    {
        ConnectDataContext connect = new ConnectDataContext();

        private static StaffDA instance;

        public static StaffDA Instance
        {
            get { if (StaffDA.instance == null) StaffDA.instance = new StaffDA(); return StaffDA.instance; }
            set { StaffDA.instance = value; }
        }

        private StaffDA() { }


    }
}
