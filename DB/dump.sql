CREATE DATABASE ManageCourse;
GO
USE ManageCourse;
GO
CREATE TABLE [User]
(ID       INT IDENTITY(1, 1) PRIMARY KEY, 
 UserName VARCHAR(100), --ten dang nhap
 PassWord VARCHAR(100), --
 Type     INT, --1:Admin, 2:Teacher, 3: Student
 Enable   BIT DEFAULT 1, 
 FromDate DATETIME, 
 ToDate   DATETIME
);
GO
CREATE TABLE Student
(ID         INT IDENTITY(1, 1) PRIMARY KEY, --ID
 Code       VARCHAR(100), --Mã sinh viên
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
 Code          VARCHAR(100), --Mã chuyên ngành
 Name          NVARCHAR(200), --Tên chuyên ngành
 TotalStudied  INT, --Tổng số sinh viên theo học
 NumberTopical INT, -- số chuyên đề bắt buộc của mỗi chuyên ngành
);
GO
CREATE TABLE Topical -- Chuyên đề
(ID            INT IDENTITY(1, 1) PRIMARY KEY, 
 Code          VARCHAR(100), --Mã chuyên đề
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
UserName, PassWord, Type
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
         SELECT u.UserName, u.PassWord, u.Type
         FROM [dbo].[User] u
         WHERE u.UserName = @UserName
               AND u.PassWord = @PassWord;
     END;
GO
ALTER PROC InsertUser @UserName   VARCHAR(100), 
                       @PassWord   VARCHAR(100), 
                       @Type       INT, 
                       @Enable     BIT, 
                       @FromDate   DATETIME, 
                       @ToDate     DATETIME, 
                       @FullName   NVARCHAR(100), 
                       @Gender     TINYINT, 
                       @DayOfBirth DATE, 
                       @Address    NVARCHAR(500)
AS
     BEGIN
         INSERT INTO dbo.[User]
         (
         --ID - this column value is auto-generated
         UserName, PassWord, Type, Enable, FromDate, ToDate
         )
         VALUES
         (
         -- ID - INT
         @UserName, -- UserName - VARCHAR
         @PassWord, -- PassWord - VARCHAR
         @Type, -- Type - INT
         @Enable, -- Enable - BIT
         @FromDate, -- FromDate - DATETIME
         @ToDate -- ToDate - DATETIME
         );
         DECLARE @IDUser INT= 0;
         SELECT @IDUser = SCOPE_IDENTITY();
         IF @IDUser > 0
            AND @Type = 3
             BEGIN
			 DECLARE @CodeStudent varchar(100);
			 SET @CodeStudent='SV'+CAST(@IDUser AS varchar(10))
                 INSERT INTO dbo.Student(Code, FullName, Gender, DayOfBirth, Address, UserID)
             VALUES
                 (@CodeStudent, -- Code - 
                  @FullName, -- FullName - NVARCHAR
                  @Gender, -- Gender - TINYINT
                  @DayOfBirth, -- DayOfBirth - DATE
                  @Address, -- Address - NVARCHAR
                  @IDUser -- UserID - INT
                 );
             END;
     END;
GO
ALTER PROC GetAllUser
AS
     BEGIN
         SELECT ID, UserName,
                    CASE Type
                        WHEN 1 THEN N'Admin'
                        WHEN 2 THEN N'Giáo viên'
                        WHEN 3 THEN N'Sinh viên'
                        ELSE ''
                    END 'Type',CASE Enable WHEN 1 THEN N'Kích hoạt' ELSE N'Hủy' END 'Enable', FromDate, ToDate
         FROM [User];
     END;
GO
CREATE PROC DeleteUser
@ID int
AS
BEGIN
	DECLARE @Type int,@IDStudent int  

	SELECT @Type=u.Type,@IDStudent=u.ID FROM dbo.[User] u WHERE u.ID=@ID
	
	DELETE dbo.[User] WHERE ID=@ID

	IF @Type=3
	BEGIN
		DELETE dbo.Student WHERE dbo.Student.ID=@IDStudent
	END
END