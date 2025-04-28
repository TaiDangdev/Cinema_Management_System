using System.Drawing;

namespace Cinema_Management_System.Models.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string MovieCode { get; set; } 
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
        public string EndDate { get; set; }
        public int TotalShowtimes { get; set; }
        public int CurrentShowtimes { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }
        public Bitmap ImageSource { get; set; }

        public MovieDTO() { }

        public MovieDTO(int id, string movieCode, string title, string decrip, string direc, string release, string language, string country, int lenght, string trailer, string startdate, string enddate, int totalShowtimes, int currentShowtimes, string genre, string status, Bitmap imageSource, int importPrice)
        {
            Id = id;
            MovieCode = movieCode; 
            Title = title;
            Description = decrip;
            Director = direc;
            ReleaseYear = release;
            Language = language;
            Country = country;
            Length = lenght;
            Trailer = trailer;
            StartDate = startdate;
            EndDate = enddate;                      
            TotalShowtimes = totalShowtimes;
            CurrentShowtimes = currentShowtimes;
            Genre = genre;
            Status = status;
            ImageSource = imageSource;
            ImportPrice = importPrice;
        }

        public MovieDTO(string movieCode, string title, string decrip, string direc, string release, string language, string country, int lenght, string trailer, string startdate, string genre, string status, string enddate, int totalShowtimes, int currentShowtimes, Bitmap imageSource, int importPrice)
        {
            MovieCode = movieCode; 
            Title = title;
            Description = decrip;
            Director = direc;
            ReleaseYear = release;
            Language = language;
            Country = country;
            Length = lenght;
            Trailer = trailer;
            StartDate = startdate;
            EndDate = enddate;                     
            TotalShowtimes = totalShowtimes;
            CurrentShowtimes = currentShowtimes;
            Genre = genre;
            Status = status;
            ImageSource = imageSource;
            ImportPrice = importPrice;
        }
    }
}
