using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO; // dùng để xử lý ảnh từ file

namespace Cinema_Management_System.Models.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public string ReleaseYear { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public int Length { get; set; }
        public string Trailer { get; set; }
        public int ImportPrice { get; set; }
        public string StartDate { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public Bitmap ImageSource { get; set; }

        public MovieDTO() { }

        //hàm khởi tạo phục vụ get  1 movie
        public MovieDTO(int id, string title, string decrip, string direc, string release, string language, string country, int lenght, string trailer, string startdate, string genre, string status, Bitmap imageSource, int importPrice)
        {
            Id = id;
            Title = title;
            Description = decrip;
            Director = direc;
            ReleaseYear = release;
            Language = language;
            Country = country;
            Length = lenght;
            Trailer = trailer;
            StartDate = startdate;
            Genre = genre;
            Status = status;
            ImageSource = imageSource;
            ImportPrice = importPrice;
        }

        //hàm khởi tạo phục vụ add 1 movie
        public MovieDTO(string title, string decrip, string direc, string release, string language, string country, int lenght, string trailer, string startdate, string genre, string status, Bitmap imageSource, int importPrice)
        {
            Title = title;
            Description = decrip;
            Director = direc;
            ReleaseYear = release;
            Language = language;
            Country = country;
            Length = lenght;
            Trailer = trailer;
            StartDate = startdate;
            Genre = genre;
            Status = status;
            ImageSource = imageSource;
            ImportPrice = importPrice;
        }
    }
}
