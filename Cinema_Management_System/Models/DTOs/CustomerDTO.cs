using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string IdFormat { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }
        public DateTime RegDate { get; set; }
        public int Point { get; set; }
        public bool IsDeleted { get; set; }

        public CustomerDTO()
        {

        }

        public CustomerDTO(int id, string idFormat, string fullName, string gender, string phoneNumber, string email, DateTime birth, DateTime regDate, int point = 0)
        {
            Id = id;
            IdFormat = idFormat;
            FullName = fullName;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            Birth = birth;
            RegDate = regDate;
            Point = point;
        }

        //public CustomerDTO(int id ,string fullName, string gender, string phoneNumber, string email, DateTime birth)
        //{
        //    Id = id;
        //    FullName = fullName;
        //    Gender = gender;
        //    PhoneNumber = phoneNumber;
        //    Email = email;
        //    Birth = birth;
        //}
    }
}
