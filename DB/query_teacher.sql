-- Thêm cột Mã giáo viên vào bảng Chuyên đề 
--  => Giáo viên phụ trách chuyên đề
alter table Topical add TeacherID int


-- Lấy danh sách chuyên ngành
CREATE PROC GetMajors
AS
     BEGIN
         SELECT m.ID, m.Code, m.Name
         FROM [dbo].[Major] m
     END
GO


-- Thêm chuyên đề
alter PROC InsertTopic @Code VARCHAR(100), 
					   @Name NVARCHAR(100), 
					   @Deadline DATETIME,
					   @NumberTeam INTEGER,
					   @NumberStudent INTEGER,
					   @Enable BIT, 
					   @MajorID INTEGER,
					   @TeacherID INTEGER
AS
     BEGIN TRAN
		BEGIN TRY
			IF EXISTS (Select *                                            -- Cấp khóa đọc trên bảng Topical
					   From Topical T
					   Where T.Code = @Code and T.MajorID = @MajorID)      -- /
			BEGIN
				--PRINT @Code + N' đã tồn tại.'
				RAISERROR (N'Mã chuyên đề %s đã tồn tại. Thêm chuyên đề không thành công!', 10, 1, @Code)
				ROLLBACK TRAN
			END

			ELSE
			BEGIN
				INSERT INTO dbo.[Topical]                 -- Cấp khóa ghi trên bảng Topical
				(Code, Name, Deadline, NumberTeam, NumberStudent, Enable, MajorID, TeacherID)
				 --  ID - value of this column is auto-generated
				VALUES
				(@Code, @Name, @Deadline, @NumberTeam, @NumberStudent, @Enable, @MajorID, @TeacherID)  -- /
			END
		END TRY

		BEGIN CATCH
			RAISERROR (N'Lỗi hệ thống.', 10, 1)
			ROLLBACK TRAN
		END CATCH
     COMMIT TRAN
GO


-- Lấy danh sách chuyên đề
alter PROC GetTopics @TeacherID INTEGER
AS
     BEGIN
         SELECT T.ID, T.Code as 'TopicCode', T.Name as 'TopicName', T.Deadline, T.NumberTeam, T.NumberStudent, T.Enable, T.FromDate, T.ToDate, T.MajorID, M.Code as 'MajorCode', M.Name as 'MajorName'
         FROM Topical T, Major M
		 WHERE T.TeacherID = @TeacherID and T.MajorID = M.ID
     END
GO


-- Lấy danh sách chuyên đề theo từ khóa
alter PROC GetTopicsByKeyWord @KeyWord nvarchar(200),
							  @TeacherID INTEGER
AS
	BEGIN TRAN
		IF NOT EXISTS (Select *                                   -- Cấp khóa đọc trên bảng Topical
					   From Topical T
					   Where T.Code like '%' + @KeyWord + '%' or T.Name like '%' + @KeyWord + '%'
							and T.TeacherID = @TeacherID)                                         -- /
		BEGIN
			RAISERROR (N'Không tìm thấy chuyên đề !', 16, 1)
			ROLLBACK TRAN
		END

		ELSE
		BEGIN
			Select T.ID, T.Code as 'TopicCode', T.Name as 'TopicName', T.Deadline, T.NumberTeam, T.NumberStudent, T.Enable, T.FromDate, T.ToDate, T.MajorID, M.Code as 'MajorCode', M.Name as 'MajorName'        -- Cấp khóa đọc trên bảng Topical và Major
			From Topical T, Major M
			Where (T.Code like '%' + @KeyWord + '%' or T.Name like '%' + @KeyWord + '%') 
					and T.TeacherID = @TeacherID and T.MajorID = M.ID
		END
     COMMIT TRAN
GO


-- Lấy danh sách sinh viên
ALTER TABLE Student ALTER COLUMN Gender int

alter PROC GetStudents
AS
	BEGIN
		SELECT S.ID, S.Code, S.FullName, S.Gender, S.DayOfBirth, S.Address, M.Name as 'MajorName'
		FROM Student S, Major M
		WHERE S.MajorID = M.ID
	END
GO


-- Lấy danh sách sinh viên theo từ khóa
alter PROC GetStudentsByKeyWord @KeyWord nvarchar(100)
AS
	BEGIN TRAN
		IF NOT EXISTS (Select *                                   -- Cấp khóa đọc trên bảng Student
						From Student S
					    Where S.Code like '%' + @KeyWord + '%' or S.FullName like '%' + @KeyWord + '%')      -- /
		BEGIN
			RAISERROR (N'Không tìm thấy sinh viên !', 16, 1)
			ROLLBACK TRAN
		END

		ELSE
		BEGIN
			Select S.Code, S.FullName, S.Gender, S.DayOfBirth, S.Address, M.Name as 'MajorName'        -- Cấp khóa đọc trên bảng Student
			From Student S, Major M
			Where (S.Code like '%' + @KeyWord + '%' or S.FullName like '%' + @KeyWord + '%') 
					and S.MajorID = M.ID
		END
     COMMIT TRAN
GO


-- Chỉnh sửa thông tin Chuyên đề
alter PROC UpdateTopic @MajorID int,
					   @TopicCode varchar(100),
					   @Deadline DateTime,
					   @NumberTeam int,
					   @NumberStudent int
AS
	BEGIN TRAN
		IF NOT EXISTS (Select *
					   From Topical T, Major M
					   Where T.Code = @TopicCode and T.MajorID = @MajorID)   --  phải trùng mã chuyên đề và mã ngành
		BEGIN
			RAISERROR (N'Không tìm thấy chuyên đề !', 16, 1)
			ROLLBACK TRAN
		END

		Update Topical
		Set Deadline = @Deadline, NumberTeam = @NumberTeam, NumberStudent = @NumberStudent
		Where Code = @TopicCode and MajorID = @MajorID
	COMMIT TRAN
GO


-- Thêm cột Học Kỳ và Năm Học vào bảng Student_Team
ALTER TABLE Student_Team DROP COLUMN Session

ALTER TABLE Student_Team add Semester int
ALTER TABLE Student_Team add Year int



-- cài khóa chính cho bảng Student_Team : ID, StudentID, TeamID, Semester, Year
-- chưa F5
ALTER TABLE Student_Team ADD CONSTRAINT PK_Student_Team PRIMARY KEY (ID, StudentID, TeamID, Semester, Year)


-- Tra cứu điểm
alter PROC LookUpScore @StudentID int,
					   @Semester int,
					   @Year int
AS
	BEGIN TRAN
		IF NOT EXISTS (Select *
					   From Student_Team S, Team_Topical P
					   Where S.Year = @Year and S.Semester = @Semester 
					     and S.StudentID = @StudentID and S.TeamID = P.ID)
		BEGIN
			RAISERROR (N'Không tìm thấy điểm theo yêu cầu!', 16, 1)
			ROLLBACK TRAN
		END

		Select T.Code as 'TopicCode', T.Name as 'TopicName', S.Point
		From Student_Team S, Team_Topical P, Topical T
		Where S.Year = @Year and S.Semester = @Semester 
			and S.StudentID = @StudentID and S.TeamID = P.ID
			and P.TopicalID = T.ID
	COMMIT TRAN
GO