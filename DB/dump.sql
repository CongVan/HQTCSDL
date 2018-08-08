﻿CREATE DATABASE ManageCourse;
GO
USE ManageCourse;
GO
CREATE TABLE [User]
(ID       INT IDENTITY(1, 1) PRIMARY KEY, 
 UserName     VARCHAR(100), --ten dang nhap
 PassWord VARCHAR(100), --
 Type     INT, --1:Admin, 2:Teacher, 3: Student
 Enable   BIT DEFAULT 1, 
 FromDate DATETIME, 
 ToDate   DATETIME
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
 Deadline      DATETIME, --Deadline của mỗi chuyên đề
 NumberTeam    INT, --Số lượng nhóm
 NumberStudent INT, --Số lượng học sinh
 Enable        BIT, --Trạng thái chuyên đề// True:mở - False: đóng
 FromDate      DATETIME, 
 ToDate        DATETIME, 
 MajorID       INT--ID chuyên ngành (chuyên đề thuộc ngành nào)

);
GO
CREATE TABLE Team_Topical
(ID        INT IDENTITY(1, 1) PRIMARY KEY, 
 Name      NVARCHAR(100), -- Tên nhóm
 TopicalID INT, --ID chuyên đề 
 Enable    BIT--Trạng thái nhóm
);
GO
CREATE TABLE Student_Team-- Sinh viên đăng ký nhóm
(ID        INT IDENTITY(1, 1) PRIMARY KEY, 
 StudentID INT, --ID sinh viên
 TeamID    INT, --ID nhóm
 Session   INT, --Học kỳ 
 Point     DECIMAL, --Điểm
 Enable    BIT--Trạng thái đăng ký
);
GO
INSERT INTO dbo.[User]
(
--ID - this column value is auto-generated
UserName, 
PassWord, 
Type
)
VALUES
(
-- ID - INT
'AD001', -- Name - VARCHAR
'123456', -- PassWord - VARCHAR
1 -- Type - INT
),
(
-- ID - INT
'TC001', -- Name - VARCHAR
'123456', -- PassWord - VARCHAR
2 -- Type - INT
),
(
-- ID - INT
'SV001', -- Name - VARCHAR
'123456', -- PassWord - VARCHAR
3 -- Type - INT
);
GO
CREATE PROC GetUser @UserName VARCHAR(100), 
                    @PassWord VARCHAR(100)
AS
     BEGIN
         SELECT u.UserName, 
                u.PassWord, 
                u.Type
         FROM [dbo].[User] u
         WHERE u.UserName = @UserName
               AND u.PassWord = @PassWord;
     END;
GO

CREATE PROC InsertUser
@UserName varchar(100),
@PassWord varchar(100),
@Type int,
@Enable   BIT, 
@FromDate DATETIME, 
@ToDate   DATETIME,
@FullName   NVARCHAR(100), 
@Gender     TINYINT, 
@DayOfBirth DATE, 
@Address    NVARCHAR(500)
AS
BEGIN
	
END
