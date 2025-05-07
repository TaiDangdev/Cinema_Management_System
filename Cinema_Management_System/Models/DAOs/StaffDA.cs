using Cinema_Management_System.Models.DTOs;
using Cinema_Management_System.ViewModels;
using Cinema_Management_System.Views.MessageBox;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Input;
using static Cinema_Management_System.AboutAccount_Form;

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

        public List<StaffDTO> GetAllStaff()
        {
            return connect.STAFFs
                .Where(staff => staff.Id != CurrentUser.StaffId)
                .Select(staff => new StaffDTO(
                    formatID(staff.Id, "NV"),
                    staff.FullName,
                    staff.Gender,
                    staff.PhoneNumber,
                    staff.Email,
                    staff.Role
                ))
                .ToList();
        }

        // hỗ trợ việc xuất file excel
        public List<StaffDTO> GetAllStaffFullInfo()
        {
            connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, connect.STAFFs);
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

        public bool DeleteStaff(int staffId)
        {
            var staff = connect.STAFFs.FirstOrDefault(s => s.Id == staffId);
            if (staff == null)
            {
                MessageBoxHelper.ShowError("Lỗi", $"Không tìm thấy nhân viên với ID {staffId} để xóa.");
                return false;
            }

            connect.STAFFs.DeleteOnSubmit(staff);
            connect.SubmitChanges();
            return true;
        }

        public bool UpdateStaff(StaffDTO staffDTO)
        {
            var staff = connect.STAFFs.FirstOrDefault(s => s.Id == staffDTO.Id);
            if (staff == null)
            {
                MessageBoxHelper.ShowError("Lỗi", $"Không tìm thấy nhân viên với ID {staffDTO.Id} để cập nhật.");
                return false;
            }

            staff.FullName = staffDTO.FullName;
            staff.Birth = string.IsNullOrWhiteSpace(staffDTO.Birth) ? DateTime.MinValue : DateTime.Parse(staffDTO.Birth);
            staff.Gender = staffDTO.Gender;
            staff.Email = staffDTO.Email;
            staff.PhoneNumber = staffDTO.PhoneNumber;
            staff.Salary = staffDTO.Salary;
            staff.Role = staffDTO.Role;
            staff.NgayVaoLam = string.IsNullOrWhiteSpace(staffDTO.NgayVaoLam) ? DateTime.MinValue : DateTime.Parse(staffDTO.NgayVaoLam);
            staff.ImageSource = staffDTO.ImageSource != null
                                ? ImageVsSQL.BitmapToByteArray(staffDTO.ImageSource)
                                : null;

            connect.SubmitChanges();
            return true;
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

        public StaffDTO GetStaffById(int staffId)
        {
            connect.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, connect.STAFFs);
            var staff = connect.STAFFs.FirstOrDefault(s => s.Id == staffId);

            if (staff == null)
            {
                MessageBoxHelper.ShowError("Lỗi", "Không tìm thấy nhân viên với Id " + staffId);
                return null;
            }
                
            return new StaffDTO
            {
                Id = staff.Id,
                FullName = staff.FullName,
                Birth = staff.Birth.ToString("dd/MM/yyyy"),
                Gender = staff.Gender,
                Email = staff.Email,
                PhoneNumber = staff.PhoneNumber,
                Salary = staff.Salary,
                Role = staff.Role,
                NgayVaoLam = staff.NgayVaoLam.ToString("dd/MM/yyyy"), 
                ImageSource = staff.ImageSource != null
                              ? ImageVsSQL.ByteArrayToBitmap(staff.ImageSource.ToArray())
                              : null
            };
        }

        public List<StaffDTO> SearchStaff(string keyword, string searchType, int limit = 15)
        {
            keyword = keyword.ToLower();
            if (searchType == "FullName")
            {
                return connect.STAFFs
                        .Where(c => c.Id != CurrentUser.StaffId && c.FullName.ToLower().Contains(keyword))
                        .OrderBy(c => c.FullName)
                        .Take(limit)
                        .Select(c => new StaffDTO(
                            formatID(c.Id, "NV"),
                            c.FullName,
                            c.Gender,
                            c.PhoneNumber,
                            c.Email,
                            c.Role
                        ))
                        .ToList();
            }
            else if (searchType == "PhoneNumber")
            {
                return connect.STAFFs
                        .Where(c => c.Id != CurrentUser.StaffId && c.PhoneNumber.Contains(keyword))
                        .OrderBy(c => c.PhoneNumber)
                        .Take(limit)
                        .Select(c => new StaffDTO(
                            formatID(c.Id, "NV"),
                            c.FullName,
                            c.Gender,
                            c.PhoneNumber,
                            c.Email,
                            c.Role
                        ))
                        .ToList();
            }
            MessageBoxHelper.ShowInfo("Thông báo", "Không tìm thấy nhân viên nào với từ khóa tìm kiếm này.");
            return new List<StaffDTO>();
        }
    }
}
