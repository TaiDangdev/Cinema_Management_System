using Cinema_Management_System.Models.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModels
{
    public class SalaryHelper
    {
        // kiểm tra xem tháng này nhân viên đã được phát lương chưa
        public static bool checkSalary()
        {
            List<string> list = StaffSalaryDA.Instance.ListDateBill();
            string timeNow = DateTime.Today.ToString("yyyy-MM-dd");
            foreach (var item in list)
            {
                if (item == timeNow)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
