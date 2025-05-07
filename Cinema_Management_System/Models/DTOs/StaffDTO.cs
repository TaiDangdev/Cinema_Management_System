using Cinema_Management_System.Models.DAOs;
using Cinema_Management_System.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Cinema_Management_System.Models.DTOs
{
    public class StaffDTO
    {
        public int Id { get; set; }
        public string IdFormat { get; set; }
        public string FullName { get; set; }
        public string Birth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }
        public string NgayVaoLam { get; set; }
        public Bitmap ImageSource { get; set; }

        public StaffDTO() { }

        //phục vụ edit
        public StaffDTO(int id, string fullName, string birth, string gender, string email, string phoneNumber, int salary, string role, string ngayVL)
        {
            Id = id;
            FullName = fullName;
            Birth = birth;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Salary = salary;
            Role = role;
            NgayVaoLam = ngayVL;
            IdFormat = StaffDA.formatID(Id);
        }

        
        public StaffDTO(int id,string fullName,string gender,string email,string phone,string role)
        {
            Id = id;
            IdFormat = StaffDA.formatID(id);
            FullName = fullName;
            Gender = gender;
            Email = email;
            PhoneNumber = phone;
            Role = role;
        }

        // phục vụ việc hiển thị datagridview
        public StaffDTO(string idFormat, string fullName, string gender, string phoneNumber, string email, string role)
        {
            IdFormat = idFormat;
            FullName = fullName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            Role = role;
        }


        //phục vụ việc thêm 1 staff
        public StaffDTO(string fullName, string birth, string gender, string email, string phoneNumber, int salary, string role, string ngayVL,Bitmap avatar)
        {
            FullName = fullName;
            Birth = birth;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Salary = salary;
            Role = role;
            NgayVaoLam = ngayVL;
            ImageSource = avatar;
        }


        //phục vụ phần information và lấy data
        public StaffDTO(int id, string fullName, string birth, string gender, string email, string phoneNumber, int salary, string role, string ngayVL, Bitmap imageSource)
        {
            Id = id;
            FullName = fullName;
            Birth = birth;
            Gender = gender;
            Email = email;
            PhoneNumber = phoneNumber;
            Salary = salary;
            Role = role;
            NgayVaoLam = ngayVL;
            IdFormat = StaffDA.formatID(Id);
            ImageSource = imageSource;
        }

    }
}
