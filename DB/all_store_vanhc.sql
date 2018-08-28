

-- Lấy danh sách chuyên ngành
CREATE PROC GetMajors
AS
     BEGIN
         SELECT m.ID, m.Code, m.Name
         FROM [dbo].[Major] m;
     END;




-- Thêm chuyên đề
CREATE PROC InsertTopic @Code          VARCHAR(100), 
                        @Name          NVARCHAR(100), 
                        @Deadline      DATETIME, 
                        @NumberTeam    INTEGER, 
                        @NumberStudent INTEGER, 
                        @Enable        BIT, 
                        @MajorID       INTEGER, 
                        @TeacherID     INTEGER
AS
     BEGIN
         BEGIN TRAN;
         BEGIN TRY
             IF EXISTS
             (
                 SELECT *                                            -- Cấp khóa đọc trên bảng Topical
                 FROM Topical T
                 WHERE T.Code = @Code
                       AND T.MajorID = @MajorID
             )      -- /
                 BEGIN
                     --PRINT @Code + N' đã tồn tại.'
                     RAISERROR(N'Mã chuyên đề %s đã tồn tại. Thêm chuyên đề không thành công!', 10, 1, @Code);
                     ROLLBACK TRAN;
                 END;
                 ELSE
                 BEGIN
                     INSERT INTO dbo.[Topical]                 -- Cấp khóa ghi trên bảng Topical
                     (Code, Name, Deadline, NumberTeam, NumberStudent, Enable, MajorID, TeacherID
                     )
                     --  ID - value of this column is auto-generated
                     VALUES
                     (@Code, 
                      @Name, 
                      @Deadline, 
                      @NumberTeam, 
                      @NumberStudent, 
                      @Enable, 
                      @MajorID, 
                      @TeacherID
                     );  -- /
                 END;
         END TRY
         BEGIN CATCH
             RAISERROR(N'Lỗi hệ thống.', 10, 1);
             ROLLBACK TRAN;
         END CATCH;
         COMMIT TRAN;
         END;




-- Lấy danh sách chuyên đề
CREATE PROC GetTopics @TeacherID INTEGER
AS
     BEGIN
         SELECT T.ID, T.Code AS 'TopicCode', T.Name AS 'TopicName', T.Deadline, T.NumberTeam, T.NumberStudent, T.Enable, T.FromDate, T.ToDate, T.MajorID, M.Code AS 'MajorCode', M.Name AS 'MajorName'
         FROM Topical T, Major M
         WHERE T.TeacherID = @TeacherID
               AND T.MajorID = M.ID;
     END;




-- Lấy danh sách chuyên đề theo từ khóa
CREATE PROC GetTopicsByKeyWord @KeyWord   NVARCHAR(200), 
                               @TeacherID INTEGER
AS
     BEGIN
         BEGIN TRAN;
         IF NOT EXISTS
         (
             SELECT *                                   -- Cấp khóa đọc trên bảng Topical
             FROM Topical T
             WHERE T.Code LIKE '%'+@KeyWord+'%'
                   OR T.Name LIKE '%'+@KeyWord+'%'
                   AND T.TeacherID = @TeacherID
         )                                         -- /
             BEGIN
                 RAISERROR(N'Không tìm thấy chuyên đề !', 16, 1);
                 ROLLBACK TRAN;
             END;
             ELSE
             BEGIN
                 SELECT T.ID, T.Code AS 'TopicCode', T.Name AS 'TopicName', T.Deadline, T.NumberTeam, T.NumberStudent, T.Enable, T.FromDate, T.ToDate, T.MajorID, M.Code AS 'MajorCode', M.Name AS 'MajorName'        -- Cấp khóa đọc trên bảng Topical và Majo
r
                 FROM Topical T, Major M
                 WHERE(T.Code LIKE '%'+@KeyWord+'%'
                       OR T.Name LIKE '%'+@KeyWord+'%')
                      AND T.TeacherID = @TeacherID
                      AND T.MajorID = M.ID;
             END;
         COMMIT TRAN;
         END;



CREATE PROC GetStudents
AS
     BEGIN
         SELECT S.ID, S.Code, S.FullName, S.Gender, S.DayOfBirth, S.Address, M.Name AS 'MajorName'
         FROM Student S, Major M
         WHERE S.MajorID = M.ID;
     END;




-- Lấy danh sách sinh viên theo từ khóa
CREATE PROC GetStudentsByKeyWord @KeyWord NVARCHAR(100)
AS
     BEGIN
         BEGIN TRAN;
         IF NOT EXISTS
         (
             SELECT *                                   -- Cấp khóa đọc trên bảng Student
             FROM Student S
             WHERE S.Code LIKE '%'+@KeyWord+'%'
                   OR S.FullName LIKE '%'+@KeyWord+'%'
         )      -- /
             BEGIN
                 RAISERROR(N'Không tìm thấy sinh viên !', 16, 1);
                 ROLLBACK TRAN;
             END;
             ELSE
             BEGIN
                 SELECT S.Code, S.FullName, S.Gender, S.DayOfBirth, S.Address, M.Name AS 'MajorName'        -- Cấp khóa đọc trên bảng Student
                 FROM Student S, Major M
                 WHERE(S.Code LIKE '%'+@KeyWord+'%'
                       OR S.FullName LIKE '%'+@KeyWord+'%')
                      AND S.MajorID = M.ID;
             END;
         COMMIT TRAN;
         END;




-- Chỉnh sửa thông tin Chuyên đề
CREATE PROC UpdateTopic @MajorID       INT, 
                        @TopicCode     VARCHAR(100), 
                        @Deadline      DATETIME, 
                        @NumberTeam    INT, 
                        @NumberStudent INT
AS
     BEGIN
         BEGIN TRAN;
         IF NOT EXISTS
         (
             SELECT *
             FROM Topical T, Major M
             WHERE T.Code = @TopicCode
                   AND T.MajorID = @MajorID
         )   --  phải trùng mã chuyên đề và mã ngành
             BEGIN
                 RAISERROR(N'Không tìm thấy chuyên đề !', 16, 1);
                 ROLLBACK TRAN;
             END;
         UPDATE Topical
           SET 
               Deadline = @Deadline, 
               NumberTeam = @NumberTeam, 
               NumberStudent = @NumberStudent
         WHERE Code = @TopicCode
               AND MajorID = @MajorID;
         COMMIT TRAN;
         END;



-- Tra cứu điểm
CREATE PROC LookUpScore @StudentID INT, 
                        @Semester  INT, 
                        @Year      INT
AS
     BEGIN
         BEGIN TRAN;
         IF NOT EXISTS
         (
             SELECT *
             FROM Student_Team S, Team_Topical P
             WHERE S.Year = @Year
                   AND S.Semester = @Semester
                   AND S.StudentID = @StudentID
                   AND S.TeamID = P.ID
         )
             BEGIN
                 RAISERROR(N'Không tìm thấy điểm theo yêu cầu!', 16, 1);
                 ROLLBACK TRAN;
             END;
         SELECT T.Code AS 'TopicCode', T.Name AS 'TopicName', S.Point
         FROM Student_Team S, Team_Topical P, Topical T
         WHERE S.Year = @Year
               AND S.Semester = @Semester
               AND S.StudentID = @StudentID
               AND S.TeamID = P.ID
               AND P.TopicalID = T.ID;
         COMMIT TRAN;
         END;



CREATE PROC GetTeams @IDTopic INT = 1
AS
BEGIN
    SELECT ID,
           Name TeamName,
           CASE
               WHEN Enable = 1 THEN
                   N'Kích hoạt'
               ELSE
                   'Hủy'
           END Status
    FROM dbo.Team_Topical
    WHERE TopicalID = @IDTopic
          AND Enable = 1;
END;



    
CREATE PROC StudentRegisterTeam    
    @idStudent INT = 0,    
    @idTeam INT = 0,    
    @idTopical INT = 0 ,  
 @Result INT OUT   
AS    
BEGIN    
   DECLARE @Semester INT = 1,  
            @Year INT = YEAR(GETDATE());  
    IF MONTH(GETDATE()) > 6  
    BEGIN  
        SET @Semester = 2;  
    END;  
    DECLARE @maxStudent INT = 0,    
            @CountStudent INT = 0,@CheckStudent INT =0;    
    
    SELECT @CheckStudent=COUNT(*)    
    FROM dbo.Team_Topical TT    
        JOIN dbo.Student_Team ST    
            ON TT.ID = ST.TeamID    
    WHERE ST.Enable = 1    
          AND TT.Enable = 1    
          --AND TT.ID =  @idTeam    
          AND ST.StudentID =@idStudent  
    AND TT.TopicalID=@idTopical AND ST.Semester=@Semester AND ST.Year= @Year;    
   -- PRINT @CheckStudent  
 IF @CheckStudent>0     
 BEGIN    
     PRINT N'Bạn đã đăng ký nhóm này!'    
  SET @Result= -2    
  RETURN  
 END     
    
    SELECT @CountStudent = COUNT(*)    
    FROM dbo.Topical T    
        JOIN dbo.Team_Topical TT    
            ON T.ID = TT.TopicalID    
        JOIN dbo.Student_Team ST    
            ON TT.ID = ST.TeamID    
    WHERE TT.ID = @idTeam    
          AND ST.Enable = 1    
          AND TT.Enable = 1    
          AND T.Enable = 1;    
    SELECT @maxStudent = T.NumberStudent    
    FROM dbo.Topical T    
    WHERE T.Enable = 1    
          AND T.ID = @idTopical;    
    IF @CountStudent + 1 > @maxStudent    
    BEGIN    
        PRINT (N'Không thể đăng ký. Chuyên đề đã đủ số lượng sinh viên!');    
        SET @Result= -1    
  RETURN   
    END;    
     
    INSERT INTO dbo.Student_Team    
    (    
        StudentID,    
        TeamID,    
        Point,    
        Enable,    
        Semester,    
        Year    
    )    
    VALUES    
    (   @idStudent, -- StudentID - int    
        @idTeam,    -- TeamID - int    
        NULL,       -- Point - decimal(18, 0)    
        1,          -- Enable - bit    
        @Semester,  -- Semester - int    
        @Year       -- Year - int    
        );    
   SET @Result= 1    
    
END; 




CREATE PROC GetStudentTeam  
@idTeam int =0  
AS  
BEGIN  
    SELECT ST.ID,S.FullName StudentName,ST.Semester,ST.Year FROM dbo.Student_Team ST   
 LEFT JOIN dbo.Student S ON ST.StudentID=S.ID  
 WHERE ST.TeamID=@idTeam  AND ST.Enable=1
END  
  



CREATE PROC GetTeamOfStudent
    @TopicID INT = 0,
    @StudentID INT = 0
AS
BEGIN
    DECLARE @Semester INT = 1,
            @Year INT = YEAR(GETDATE());
    IF MONTH(GETDATE()) > 6
    BEGIN
        SET @Semester = 2;
    END;
    SELECT ST.ID IDStudent,
           TT.Name NameTeam,
           TT.ID IDTeam
    FROM dbo.Team_Topical TT
         JOIN dbo.Student_Team ST
            ON ST.TeamID = TT.ID
    WHERE TT.TopicalID = @TopicID
          AND ST.StudentID = @StudentID
          AND ST.Enable = 1
          AND TT.Enable = 1
          AND ST.Semester = @Semester
          AND ST.Year = @Year;

END;



  
CREATE PROC GetUser @UserName VARCHAR(100),   
                    @PassWord VARCHAR(100)  
AS  
     BEGIN  
         SELECT u.ID,u.UserName, u.PassWord, u.Type,Convert(varchar(20),u.FromDate,111) FromDate,Convert(varchar(20),u.ToDate,111) ToDate   
         FROM [dbo].[User] u  
         WHERE u.UserName = @UserName  
               AND u.PassWord = @PassWord;  
     END; 




CREATE PROC InsertUser @UserName   VARCHAR(100), 
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




CREATE PROC GetAllUser
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




	CREATE PROC GetTeamOfTopical @TopicalID INT
AS
BEGIN

    DECLARE @Semester INT = 1,
            @Year INT = YEAR(GETDATE());
    IF MONTH(GETDATE()) > 6
    BEGIN
        SET @Semester = 2;
    END;
    SELECT TT.ID,
           --TT.TopicalID,    
           TT.Name NameTeam,
           COUNT(ST.ID) SL
    FROM dbo.Team_Topical TT
        LEFT JOIN
        (
            SELECT *
            FROM dbo.Student_Team ST
            WHERE ST.Semester = @Semester
                  AND ST.Year = @Year
                  AND ST.Enable = 1
        ) ST
            ON TT.ID = ST.TeamID
    WHERE TT.TopicalID = @TopicalID
          AND TT.Enable = 1
    GROUP BY TT.ID,
             TT.TopicalID,
             TT.Name;
END;




CREATE PROC DeleteUser
@ID int
AS
BEGIN
	DECLARE @Type int

	SELECT @Type=u.Type FROM dbo.[User] u WHERE u.ID=@ID
	
	DELETE dbo.[User] WHERE ID=@ID

	IF @Type=3
	BEGIN
		DELETE dbo.Student WHERE dbo.Student.UserID=@ID
	END
END




CREATE PROC GetStudentFroUser @ID INT
AS
     BEGIN
         SELECT s.ID, s.Code, s.FullName, s.Gender, CONVERT(VARCHAR(20), s.DayOfBirth, 111), s.Address, s.MajorID, s.UserID
         FROM dbo.Student s WHERE s.UserID=@ID;
     END;



CREATE PROC GetUserFromID @ID INT
AS
     BEGIN
         SELECT u.UserName, u.PassWord,u.Enable ,u.Type, CONVERT(VARCHAR(20), u.FromDate, 111) FromDate, CONVERT(VARCHAR(20), u.ToDate, 111) ToDate
         FROM [dbo].[User] u
         WHERE u.ID = @ID;
     END;




CREATE PROC GetStudentFromUser @ID INT
AS
     BEGIN
         SELECT s.ID, s.Code, s.FullName, s.Gender, CONVERT(VARCHAR(20), s.DayOfBirth, 111) DayOfBirth, s.Address, s.MajorID, s.UserID
         FROM dbo.Student s
         WHERE s.UserID = @ID;
     END;





CREATE PROC UpdateUser @UserName   VARCHAR(100), 
                      @PassWord   VARCHAR(100), 
                      @Type       INT, 
                      @Enable     BIT, 
                      @FromDate   DATETIME, 
                      @ToDate     DATETIME, 
                      @FullName   NVARCHAR(100), 
                      @Gender     TINYINT, 
                      @DayOfBirth DATE, 
                      @Address    NVARCHAR(500),
					  @ID int 
AS
     BEGIN
         UPDATE dbo.[User]
         SET
             UserName = @UserName, -- VARCHAR
             PassWord = @PassWord, -- VARCHAR
             Type = @Type, -- INT
             Enable = @Enable, -- BIT
             FromDate = @FromDate, -- DATETIME
             ToDate = @ToDate -- DATETIME

         WHERE dbo.[User].ID=@ID
         
         IF  @Type = 3
             BEGIN
                 UPDATE dbo.Student
                 SET
                    
                     dbo.Student.FullName = @FullName, -- NVARCHAR
                     dbo.Student.Gender = @Gender, -- TINYINT
                     dbo.Student.DayOfBirth = @DayOfBirth, -- DATE
                     dbo.Student.Address = @Address -- NVARCHAR
                     --dbo.Student.MajorID = 0, -- INT
                     where dbo.Student.UserID = @ID -- INT

             END;
     END;




CREATE PROC TransferTeam  
    @idOldTeam INT,  
    @idNewTeam INT,  
    @idStudent INT,  
    @Result INT OUT  
AS  
BEGIN  
    SET NOCOUNT ON;  
    SET @Result = 0;  
    DECLARE @Semester INT = 1,  
            @Year INT = YEAR(GETDATE());  
    IF MONTH(GETDATE()) > 6  
    BEGIN  
        SET @Semester = 2;  
    END;  
  
    UPDATE ManageCourse.dbo.Student_Team  
    SET Enable = 0  
    WHERE TeamID = @idOldTeam  
          AND StudentID = @idStudent  
          AND Semester = @Semester  
          AND Year = @Year;  
  
    IF @@ROWCOUNT = 0  
    BEGIN  
        SET @Result = -1;  
        RETURN;  
    END;  
  
    INSERT INTO ManageCourse.dbo.Student_Team  
    (  
        StudentID,  
        TeamID,  
        Point,  
        Enable,  
        Semester,  
        Year  
    )  
    VALUES  
    (   @idStudent, -- StudentID - int    
        @idNewTeam, -- TeamID - int    
        0,          -- Point - decimal(18, 0)    
        1,          -- Enable - bit    
        @Semester,  -- Semester - int    
        @Year       -- Year - int    
        );  
    IF @@ROWCOUNT = 0  
    BEGIN  
        SET @Result = -2;  
        RETURN;  
    END;  
  
    SET @Result = 1;  
  
  
END;



CREATE PROC	InsertMajor
@Name nvarchar(200),
@NumberTopical int 
AS
BEGIN
	DECLARE @Code varchar(100)='MJ'
	SELECT @Code=@Code+CAST(ISNULL(MAX(m.ID),1) AS  varchar(10)) FROM dbo.Major m
	INSERT INTO dbo.Major
	(
	    --ID - this column value is auto-generated
	    Code,
	    Name,
	    TotalStudied,
	    NumberTopical
	)
	VALUES
	(
	    -- ID - int
	    @Code, -- Code - varchar
	    @Name, -- Name - nvarchar
	    @NumberTopical, -- TotalStudied - int
	    0 -- NumberTopical - int
	)


END




Create PROC	UpdateMajor
@Name nvarchar(200),
@NumberTopical int,
@ID int 
AS
BEGIN
	
	UPDATE dbo.Major
	SET
	    dbo.Major.Name = @Name, -- nvarchar
	    dbo.Major.NumberTopical =@NumberTopical -- int
		WHERE dbo.Major.ID=@ID

END




Create PROC	DeleteMajor
@ID int 
AS
BEGIN
	
	DELETE dbo.Major
		WHERE dbo.Major.ID=@ID

END



CREATE PROC GetTopic @IDMajor INT = 0
AS
     BEGIN
         IF ISNULL(@IDMajor, 0) = 0
             BEGIN
                 SELECT t.ID, t.Name TopicName, m.Name MajorName,
                                                       CASE
                                                           WHEN t.Enable = 1 THEN N'Kích hoạt'
                                                           ELSE 'Hủy'
                                                       END 'Enable', t.FromDate, t.ToDate
                 FROM
                 (
                     SELECT m.Name, m.ID
                     FROM dbo.Major m
                 ) m
                 INNER JOIN dbo.Topical t ON m.ID = t.MajorID;
             END;
             ELSE
             BEGIN
                 SELECT t.ID, t.Name TopicName, m.Name MajorName,
                                                       CASE
                                                           WHEN t.Enable = 1 THEN N'Kích hoạt'
                                                           ELSE 'Hủy'
                                                       END 'Enable', t.FromDate, t.ToDate
                 FROM
                 (
                     SELECT m.Name, m.ID
                     FROM dbo.Major m
                     WHERE m.ID = @IDMajor
                 ) m
                 INNER JOIN dbo.Topical t ON m.ID = t.MajorID;
             END;
     END;




CREATE PROC GetTopicFromMajor @IDMajor INT = 0
AS
     BEGIN
         IF ISNULL(@IDMajor, 0) = 0
             BEGIN
                 SELECT t.ID, t.Name TopicName, m.Name MajorName,
                                                       CASE
                                                           WHEN t.Enable = 1 THEN N'Kích hoạt'
                                                           ELSE N'Hủy'
                                                       END 'Enable', t.FromDate, t.ToDate
                 FROM
                 (
                     SELECT m.Name, m.ID
                     FROM dbo.Major m
                 ) m
                 INNER JOIN dbo.Topical t ON m.ID = t.MajorID;
             END;
             ELSE
             BEGIN
                 SELECT t.ID, t.Name TopicName, m.Name MajorName,
                                                       CASE
                                                           WHEN t.Enable = 1 THEN N'Kích hoạt'
                                                           ELSE N'Hủy'
                                                       END 'Enable', t.FromDate, t.ToDate
                 FROM
                 (
                     SELECT m.Name, m.ID
                     FROM dbo.Major m
                     WHERE m.ID = @IDMajor
                 ) m
                 INNER JOIN dbo.Topical t ON m.ID = t.MajorID;
             END;
     END;



CREATE PROC UpdateTopicalAdmin
@IDT int,
@Enable int,
@FromDate date,
@ToDate date
AS
BEGIN
	UPDATE dbo.Topical
	SET
	   
	    dbo.Topical.Enable = @Enable, -- bit
	    dbo.Topical.FromDate = @FromDate, -- datetime
	    dbo.Topical.ToDate = @ToDate -- datetime
	    WHERE dbo.Topical.ID =@IDT
END

