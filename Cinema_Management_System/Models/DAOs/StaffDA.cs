using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DAOs
{
    public class StaffDA
    {
        ConnectDataContext connect = new ConnectDataContext();

        private static int soLuongChuSo;

        private static StaffDA instance;

        public static StaffDA Instance
        {
            get { if (StaffDA.instance == null) StaffDA.instance = new StaffDA(); return StaffDA.instance; }
            set { StaffDA.instance = value; }
        }

        private StaffDA() { }

        public List<object> GetAllStaff()
        {
            return connect.STAFFs.Select(staff => new
            {
                IdFormat = formatID(staff.Id,"NV"),
                FullName = staff.FullName,
                Gender = staff.Gender,
                PhoneNumber = staff.PhoneNumber,
                Email = staff.Email,
                Role = staff.Role
            }).Cast<object>().ToList();
        }

        // hỗ trợ hiển thị datagridview
        public List<StaffDTO> GetAllStaffFullInfo()
        {
            var staffData = connect.STAFFs.ToList();

            return staffData.Select(staff => new StaffDTO(
                staff.Id,
                staff.FullName,
                staff.Birth.ToString("dd/MM/yyyy"),
                staff.Gender,
                staff.Email,
                staff.PhoneNumber,
                staff.Salary,
                staff.Role,
                staff.NgayVaoLam.ToString("dd/MM/yyyy"),
                null 
            )).ToList();
        }

        // add 1 staff
        public int AddStaff(StaffDTO staffDTO)
        {
            STAFF staff = new STAFF
            {
                FullName = staffDTO.FullName,
                Birth = string.IsNullOrWhiteSpace(staffDTO.Birth) ? DateTime.MinValue : DateTime.ParseExact(staffDTO.Birth, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Gender = staffDTO.Gender,
                Email = staffDTO.Email,
                PhoneNumber = staffDTO.PhoneNumber,
                Salary = staffDTO.Salary,
                Role = staffDTO.Role,
                NgayVaoLam = string.IsNullOrWhiteSpace(staffDTO.NgayVaoLam) ? DateTime.MinValue : DateTime.ParseExact(staffDTO.NgayVaoLam, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                ImageSource = staffDTO.ImageSource != null ? ImageVsSQL.BitmapToByteArray(staffDTO.ImageSource) : null
            };

            connect.STAFFs.InsertOnSubmit(staff);
            connect.SubmitChanges();

            return staff.Id;
        }

        public static string formatID(int id, string type = "NV")
        {
            string format = "";
            if (soLuongChuSo < 4)
            {
                format = "000";
            }
            else
            {
                for (int k = 0; k < soLuongChuSo; k++)
                {
                    format += "0";
                }
            }
            string ID = id.ToString();

            int i = format.Length - 1;
            int j = ID.Length - 1;
            char[] s1 = format.ToCharArray();
            char[] s2 = ID.ToCharArray();
            while (i >= 0 && j >= 0)
            {
                s1[i--] = s2[j--];
            }

            format = new string(s1);
            format = type + format;
            return format;
        }

        public int GetIdFromIdFormat(string idFormat)
        {
            string idStr = idFormat.Replace("NV", "");
            return int.Parse(idStr);
        }

        public bool IsPhoneNumberExists(string phoneNumber)
        {
            return connect.STAFFs.Any(s => s.PhoneNumber == phoneNumber);
        }




    }
}
