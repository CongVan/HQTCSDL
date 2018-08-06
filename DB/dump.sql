--CREATE DATABASE ManageCourse;
--GO
USE ManageCourse;
GO
CREATE TABLE [User]
(ID       INT IDENTITY(1, 1) PRIMARY KEY, 
 Name     VARCHAR(100), --ten dang nhap
 PassWord VARCHAR(100), --
 Type     INT--1:Admin, 2:Teacher, 3: Student
);
GO
CREATE TABLE Student
(ID         INT IDENTITY(1, 1) PRIMARY KEY, --ID
 Code       INT, --Mã sinh viên
 FullName   NVARCHAR(100), --Tên sinh viên
 Gender     TINYINT, --1: Nam, 2: Nu
 DayOfBirth DATE, --Ngày sinh
 Address    NVARCHAR(500), --Địa chỉ
 MajorID    INT, --ID Chuyên ngành
 UserID     INT, --ID người dùng
);
GO
CREATE TABLE Major--Bảng chuyên ngành
(ID            INT IDENTITY(1, 1) PRIMARY KEY, 
 Code          INT, --Mã chuyên ngành
 Name          NVARCHAR(200), --Tên chuyên ngành
 TotalStudied  INT, --Tổng số sinh viên theo học
 NumberTopical INT, -- số chuyên đề bắt buộc của mỗi chuyên ngành
);
GO
CREATE TABLE Topical -- Chuyên đề
(ID            INT IDENTITY(1, 1) PRIMARY KEY, 
 Code          INT, --Mã chuyên đề
 Name          NVARCHAR(200), --Tên chuyên đề
 --NumberClass INT,--Số sinh viên tối đa của mỗi chuyên đề
 Deadline      DATETIME, --Deadline của mỗi chuyên đề
 NumberTeam    INT, --Số lượng nhóm
 NumberStudent INT, --Số lượng học sinh
 Enable        BIT, --Trạng thái chuyên đề// True:mở - False: đóng
 MajorID       INT--ID chuyên ngành (chuyên đề thuộc ngành nào)
);
GO
CREATE TABLE [Subject]--Môn học
(ID        INT IDENTITY(1, 1) PRIMARY KEY, 
 Name      NVARCHAR(200), --Tên môn học
 TopicalID INT, --ID chuyên đề(Môi chuyên đề có nhiều môn học)
 Enable bit
);
CREATE TABLE Student_Subject-- Sinh viên đăng ký môn học 
(ID        INT IDENTITY(1, 1) PRIMARY KEY, 
 StudentID INT, --ID sinh viên
 SubjectID INT, --ID môn họcs
 Session   INT, --Học kỳ 
 Point     DECIMAL--Điểm

);
GO