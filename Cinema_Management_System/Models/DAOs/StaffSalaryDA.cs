using Cinema_Management_System.Views.MessageBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Cinema_Management_System.AboutAccount_Form;

namespace Cinema_Management_System.Models.DAOs
{
    public class StaffSalaryDA
    {
        ConnectDataContext connect = new ConnectDataContext();

        private static StaffSalaryDA instance;

        public static StaffSalaryDA Instance
        {
            get { if (StaffSalaryDA.instance == null) StaffSalaryDA.instance = new StaffSalaryDA(); return StaffSalaryDA.instance; }
            set { StaffSalaryDA.instance = value; }
        }

        private StaffSalaryDA() { }

        // phát lương cho tất cả nhân viên
        public int PhatLuongAll()
        {
            DateTime today = DateTime.Today;
            var staffToPay = connect.STAFFs
                .Where(s => s.Id != CurrentUser.StaffId &&
                            !connect.Staff_Salaries.Any(ss =>
                                ss.Staff_Id == s.Id &&
                                ss.BillDate.HasValue &&
                                ss.BillDate.Value.Month == today.Month &&
                                ss.BillDate.Value.Year == today.Year))
                .ToList();

            int count = 0;

            foreach (var staff in staffToPay)
            {
                if (staff.Salary > 0)
                {
                    connect.Staff_Salaries.InsertOnSubmit(new Staff_Salary
                    {
                        Staff_Id = staff.Id,
                        BillDate = today,
                        Total = staff.Salary
                    });
                    staff.Salary = 0; 
                    count++;
                }
            }
            
            connect.SubmitChanges();
            connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, connect.STAFFs);
            return count;
        }

        public bool IsSalaryPaidThisMonth(int staffId, DateTime date)
        {
            return connect.Staff_Salaries.Any(s =>
                s.Staff_Id == staffId &&
                s.BillDate.HasValue &&
                s.BillDate.Value.Month == date.Month &&
                s.BillDate.Value.Year == date.Year);
        }

        public bool PhatLuongTheoId(int staffId, DateTime billDate, int total)
        {
            try
            {
                var staff = connect.STAFFs.SingleOrDefault(s => s.Id == staffId);
                if (staff == null) return false;

                Staff_Salary newSalary = new Staff_Salary
                {
                    Staff_Id = staffId,
                    BillDate = billDate,
                    Total = total
                };
                connect.Staff_Salaries.InsertOnSubmit(newSalary);
                staff.Salary = 0;
                connect.SubmitChanges();
                connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, connect.STAFFs);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // lấy toàn bộ ngày tháng năm phát lương từ bảng Staff_Salary
        public List<string> ListDateBill()
        {
            List<string> list = new List<string>();
            var dates = from salary in connect.Staff_Salaries
                        select salary.BillDate;
            foreach (var date in dates)
            {
                if (date.HasValue)
                {
                    string formattedDate = date.Value.ToString("yyyy-MM-dd");
                    string[] s = formattedDate.Split(' ');
                    list.Add(s[0]);
                }
            }

            return list;
        }
    }
}
