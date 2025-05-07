using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Cinema_Management_System.ViewModels
{
    public class PasswordHelper
    {
        // mã hóa mật khẩu bằng SHA256
        public static string EncryptSHA256(string input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                foreach (byte b in data)
                {
                    sBuilder.Append(b.ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        // kiểm tra tính bảo mật của mật khẩu
        public static bool IsValidPassword(string password)
        {
            return password.Length >= 8 &&
                   password.Any(char.IsUpper) &&
                   password.Any(char.IsLower) &&
                   password.Any(char.IsDigit);
        }
    }
}