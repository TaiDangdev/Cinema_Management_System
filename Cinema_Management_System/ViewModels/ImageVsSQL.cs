using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema_Management_System.ViewModels
{
    // class hỗ trợ việc chuyển ảnh để lưu vào CSDL
    public class ImageVsSQL
    {
        // chuyển đổi Bitmap thành mảng Byte để lưu vào CSDL
        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            if (bitmap == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        // chuyển đổi mảng Byte thành Bitmap để hiển thị ảnh
        public static Bitmap ByteArrayToBitmap(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0) return null;
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return new Bitmap(ms);
            }
        }
    }
}
