using System;
using System.Linq;

namespace Cinema_Management_System.ViewModels.MovieManagementVM.Feature
{
    public static class SearchMovieHelper
    {
        public static int LevenshteinDistance(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1)) return string.IsNullOrEmpty(s2) ? 0 : s2.Length;
            if (string.IsNullOrEmpty(s2)) return s1.Length;

            int[,] matrix = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                matrix[i, 0] = i;
            for (int j = 0; j <= s2.Length; j++)
                matrix[0, j] = j;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost
                    );
                }
            }

            return matrix[s1.Length, s2.Length];
        }

        // readonly là hằng số runtime gán 1 lần lúc chạy
        private static readonly string[] VietnameseSigns = new string[]
        {
            "aàảãáạăằẳẵắặâầẩẫấậ",
            "dđ",
            "eèẻẽéẹêềểễếệ",
            "iìỉĩíị",
            "oòỏõóọôồổỗốộơờởỡớợ",
            "uùủũúụưừửữứự",
            "yỳỷỹýỵ"
        };

        // chuyển chuỗi tiếng việt có dấu thành không dấu
        public static string RemoveVietnameseSigns(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            str = str.ToLower();
            for (int i = 0; i < VietnameseSigns.Length; i++)
            {
                foreach (char c in VietnameseSigns[i].Skip(1))
                {
                    str = str.Replace(c, VietnameseSigns[i][0]);
                }
            }
            return str;
        }
    }
}
