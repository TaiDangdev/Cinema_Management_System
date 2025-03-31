CREATE DATABASE CinemaManagement

GO

USE CinemaManagement

GO

CREATE TABLE STAFF
(
	Id int primary key identity(1,1),
	FullName nvarchar(100) not null,
	Birth smalldatetime not null,
	Gender nvarchar(100) not null,
	Email nvarchar(100) not null,
	PhoneNumber nvarchar(20) not null,
	Salary int not null,
	Role nvarchar(30) not null,
	NgayVaoLam smalldatetime not null,
	ImageSource	varbinary(max)
)
--tân từ cho bảng STAFF: mỗi nhân viên có id riêng làm khóa chính để phân biệt, có họ tên,ngày sinh,giới tính,email,sđt,mức lương,chức vụ,ngày vào làm,ảnh thẻ(sẽ dùng ảnh mặc định khi nhân viên vừa vào làm)

CREATE TABLE ACCOUNTS
(
	id INT PRIMARY KEY IDENTITY(1, 1),
	Username VARCHAR(40) NOT NULL UNIQUE,
	Password VARCHAR(40) NOT NULL,
	Staff_Id INT NOT NULL,
	CONSTRAINT FK_StaffId FOREIGN KEY (Staff_Id) REFERENCES STAFF(Id)
)
--tân từ: mỗi tài khoản có 1 id riêng làm khóa chính,có tên tk riêng,mk,có khóa ngoại Staff_Id tham chiếu tới id của bảng nhân viên để phân biệt tài khoản này là của ai

INSERT INTO STAFF (FullName, Birth, Gender, Email, PhoneNumber, Salary, Role, NgayVaolam, ImageSource)
VALUES ('DevPro', '1990-08-02', 'Nam', 'tnhatnguyen.dev2805@gmail.com', '0123456789', 5000000, 'Admin', '2022-03-25', NULL);

INSERT INTO ACCOUNTS (Username, Password, Staff_Id)
VALUES ('admin', 'admin123', 1);

GO 
-- bảng MOVIES 

CREATE TABLE MOVIE
(
    id INT PRIMARY KEY IDENTITY(1, 1),
    Title NVARCHAR(100) not null,
    Description NVARCHAR(500) not null,
    Genre nvarchar(100) not null,
    Director NVARCHAR(50) not null,
    ReleaseYear int not null,
    Language NVARCHAR(20) not null,
    Country NVARCHAR(20) not null,
    Length INT not null,
    Trailer NVARCHAR(200) not null,
    StartDate SMALLDATETIME not null,
    Status nvarchar(50) not null,
	ImportPrice int not null,
    ImageSource varbinary(max) not null,
);

--tân từ: mỗi bộ phim có 1 id riêng để phân biệt với các bộ phim khác,có tiêu đề,miêu tả về phim,thể loại phim,đạo diễn 
--năm ra mắt,ngôn ngữ trong phim,quốc gia sx,thời lượng phim(phút),link trailer,ngày ra mắt phim,trạng thái phim trong rạp(đang phát hành,ngừng ph),đường dẫn ảnh phim

SELECT * FROM MOVIE


DROP TABLE MOVIE;