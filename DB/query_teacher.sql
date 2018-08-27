-- Thêm cột Mã giáo viên vào bảng Chuyên đề 
--  => Giáo viên phụ trách chuyên đề
ALTER TABLE Topical
ADD TeacherID INT;
GO
-- Lấy danh sách chuyên ngành
CREATE PROC GetMajors
AS
     BEGIN
         SELECT m.ID, m.Code, m.Name
         FROM [dbo].[Major] m;
     END;
GO

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
         BEGIN TRAN
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
                     (Code, Name, Deadline, NumberTeam, NumberStudent, Enable, MajorID, TeacherID)
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
GO

-- Lấy danh sách chuyên đề
ALTER PROC GetTopics @TeacherID INTEGER
AS
     BEGIN
         SELECT T.ID AS 'TopicID', T.Code AS 'TopicCode', T.Name AS 'TopicName', T.Deadline, COUNT(TT.TopicalID) AS 'NumberOfTeam', T.NumberTeam, T.NumberStudent, T.Enable, T.FromDate, T.ToDate, T.MajorID, M.Code AS 'MajorCode', M.Name AS 'MajorName'
         FROM Topical T, Major M, Team_Topical TT
         WHERE T.TeacherID = @TeacherID
               AND T.MajorID = M.ID
			   AND TT.TopicalID = T.ID
		 GROUP BY T.ID, T.Code, T.Name, T.Deadline, T.NumberTeam, T.NumberStudent, T.Enable, T.FromDate, T.ToDate, T.MajorID, M.Code, M.Name;
     END;
GO

-- Lấy danh sách chuyên đề theo từ khóa
ALTER PROC GetTopicsByKeyWord @KeyWord   NVARCHAR(200), 
                               @TeacherID INTEGER
AS
     BEGIN
         BEGIN TRAN
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
                 SELECT T.ID AS 'TopicID', T.Code AS 'TopicCode', T.Name AS 'TopicName', T.Deadline, COUNT(TT.TopicalID) AS 'NumberOfTeam', T.NumberTeam, T.NumberStudent, T.Enable, T.FromDate, T.ToDate, T.MajorID, M.Code AS 'MajorCode', M.Name AS 'MajorName'        -- Cấp khóa đọc trên bảng Topical, Major và Team_Topical
                 FROM Topical T, Major M, Team_Topical TT
                 WHERE(T.Code LIKE '%'+ @KeyWord +'%'
                       OR T.Name LIKE '%' + @KeyWord + '%')
                      AND T.TeacherID = @TeacherID
                      AND T.MajorID = M.ID
					  AND TT.TopicalID = T.ID
				 GROUP BY T.ID, T.Code, T.Name, T.Deadline, T.NumberTeam, T.NumberStudent, T.Enable, T.FromDate, T.ToDate, T.MajorID, M.Code, M.Name;
             END;
         COMMIT TRAN;
	END;
GO

-- Lấy danh sách sinh viên
ALTER TABLE Student ALTER COLUMN Gender INT;
GO
CREATE PROC GetStudents
AS
     BEGIN
         SELECT S.ID, S.Code, S.FullName, S.Gender, S.DayOfBirth, S.Address, M.Name AS 'MajorName'
         FROM Student S, Major M
         WHERE S.MajorID = M.ID;
     END;
GO

-- Lấy danh sách sinh viên theo từ khóa
CREATE PROC GetStudentsByKeyWord @KeyWord NVARCHAR(100)
AS
     BEGIN
         BEGIN TRAN
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
GO

-- Chỉnh sửa thông tin Chuyên đề
CREATE PROC UpdateTopic @MajorID       INT, 
                        @TopicCode     VARCHAR(100), 
                        @Deadline      DATETIME, 
                        @NumberTeam    INT, 
                        @NumberStudent INT
AS
     BEGIN
         BEGIN TRAN
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
GO

-- Thêm cột Học Kỳ và Năm Học vào bảng Student_Team
ALTER TABLE Student_Team DROP COLUMN Session;
GO
ALTER TABLE Student_Team
ADD Semester INT;
GO
ALTER TABLE Student_Team
ADD Year INT;
GO

-- Tra cứu điểm
CREATE PROC LookUpScore @StudentID INT, 
                        @Semester  INT, 
                        @Year      INT
AS
     BEGIN
         BEGIN TRAN
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
GO

-- Tạo nhóm
CREATE PROC InsertTeam @Name NVARCHAR(200),
				       @TopicID INT,
					   @Enable BIT
AS
	BEGIN
		BEGIN TRAN
			BEGIN TRY
				INSERT INTO dbo.[Team_Topical]
				--  ID - value of this column is auto-generated
				(Name, TopicalID, Enable)
				VALUES
				(@Name, @TopicID, @Enable);

				IF EXISTS
				(
					SELECT *
					FROM Topical T, Team_Topical TT
					WHERE TT.TopicalID = @TopicID
					  AND TT.TopicalID = T.ID
					HAVING COUNT (TT.TopicalID) > (SELECT T.NumberTeam
									               FROM Topical T
									               WHERE T.ID = @TopicID)
				)
				BEGIN
					DECLARE @TopicName NVARCHAR(200);
					SET @TopicName = (SELECT T.Name
									  FROM Topical T
									  WHERE T.ID = @TopicID);

					RAISERROR(N'Chuyên đề %s đã đạt số lượng nhóm tối đa. Tạo nhóm không thành công!', 10, 1, @TopicName);
					ROLLBACK TRAN;
				END;
			END TRY
			BEGIN CATCH
				RAISERROR(N'Lỗi hệ thống.', 10, 1);
				ROLLBACK TRAN;
			END CATCH;
		COMMIT TRAN;
	END;
GO