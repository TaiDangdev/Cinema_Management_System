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

