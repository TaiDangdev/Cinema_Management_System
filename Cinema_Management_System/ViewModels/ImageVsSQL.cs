using System;
using System.Drawing;
using System.IO;

namespace Cinema_Management_System.ViewModels
{
    public class ImageVsSQL
    {
        // chuyển đổi Bitmap thành mảng Byte để lưu vào CSDL
        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            if (bitmap == null) return null;
            using (MemoryStream ms = new MemoryStream())
            {
                try
                {
                    Bitmap clone = new Bitmap(bitmap);
                    clone.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    clone.Dispose();
                    return ms.ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi chuyển đổi Bitmap sang ByteArray: " + ex.Message);
                }
            }
        }

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
