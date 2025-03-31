using Cinema_Management_System.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.Models.DAOs
{
    public class UserDA
    {
        // lấy thông tin của 1 user cụ thể theo tài khoản (username,password)
        // Trả về một object ở đây là UserDTO ở class DTOs để có thể tái sử dụng
        public static UserDTO GetUser(string username,string password)
        {
            using (var db = new ConnectDataContext())
            {
                var user = (from acc in db.ACCOUNTs
                            join staff in db.STAFFs on acc.Staff_Id equals staff.Id
                            where acc.Username == username && acc.Password == password
                            select new UserDTO { Id = staff.Id, Username = acc.Username})
                            .FirstOrDefault();
                return user;
            }
        }



    }
}
