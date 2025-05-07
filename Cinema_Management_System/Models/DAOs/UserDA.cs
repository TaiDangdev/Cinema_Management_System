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

        private static UserDA instance;

        public static UserDA Instance
        {
            get { if (UserDA.instance == null) UserDA.instance = new UserDA(); return UserDA.instance; }
            set { UserDA.instance = value; }
        }

        private UserDA() { }

        public UserDTO GetUser(string username, string password)
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

        public static bool ChangePassword(int staffId, string oldPassword, string newPassword)
        {
            using (var db = new ConnectDataContext())
            {
                var account = db.ACCOUNTs
                                .FirstOrDefault(acc => acc.Staff_Id == staffId && acc.Password == oldPassword);
                if (account != null)
                {
                    account.Password = newPassword;
                    db.SubmitChanges(); 
                    return true; 
                }
                return false;
            }
        }

        public static UserDTO GetUserByStaffId(int staffId)
        {
            using (var db = new ConnectDataContext())
            {
                var user = (from acc in db.ACCOUNTs
                            join staff in db.STAFFs on acc.Staff_Id equals staff.Id
                            where staff.Id == staffId
                            select new UserDTO
                            {
                                Id = staff.Id,
                                Username = acc.Username,
                            }).FirstOrDefault();
                return user;
            }
        }

        public void AddUser(int staffId, string username, string password)
        {
            using (var db = new ConnectDataContext())
            {
                var account = new ACCOUNT
                {
                    Staff_Id = staffId,
                    Username = username,
                    Password = password
                };

                db.ACCOUNTs.InsertOnSubmit(account);
                db.SubmitChanges();
            }
        }
    }
}
