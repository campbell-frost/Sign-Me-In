
CREATE TABLE [Account] (
  [AccountID] INT,
  [Username] NVARCHAR(255),
  [PasswordHash] NVARCHAR(255),
  PRIMARY KEY ([AccountID])
);

CREATE TABLE [HubEmployee] (
  [EmployeeID] INT,
  [FirstName] NVARCHAR(255),
  [LastName] NVARCHAR(255),
  [Initials] NVARCHAR(5),
  [Role] NVARCHAR(20),
  [AccountID] INT,
  PRIMARY KEY ([EmployeeID]),
  CONSTRAINT [FK_HubEmployee.AccountID]
    FOREIGN KEY ([AccountID])
      REFERENCES [Account]([AccountID])
);

CREATE TABLE [Manager] (
  [ManagerID] INT,
  [FirstName] NVARCHAR(255),
  [LastName] NVARCHAR(255),
  [AccountID] INT,
  PRIMARY KEY ([ManagerID])
);

CREATE TABLE [SecurityAnswers] (
  [AnswerID] INT,
  [AccountID] INT,
  [QuestionID] INT,
  [AnswerHash] NVARCHAR(255),
  PRIMARY KEY ([AnswerID]),
  CONSTRAINT [FK_SecurityAnswers.AccountID]
    FOREIGN KEY ([AccountID])
      REFERENCES [Account]([AccountID])
);

CREATE TABLE [Course] (
  [CourseID] INT,
  [CourseName] NVARCHAR(20),
  PRIMARY KEY ([CourseID])
);

CREATE TABLE [Instructor] (
  [InstructorID] INT,
  [LastName] NVARCHAR(255),
  [FirstName] NVARCHAR(255),
  PRIMARY KEY ([InstructorID])
);

CREATE TABLE [Student] (
  [StudentID] INT,
  [FirstName] NVARCHAR(255),
  [LastName] NVARCHAR(255),
  [CourseID] INT,
  [InstructorID] INT,
  PRIMARY KEY ([StudentID]),
  CONSTRAINT [FK_Student.InstructorID]
    FOREIGN KEY ([InstructorID])
      REFERENCES [Instructor]([InstructorID]),
  CONSTRAINT [FK_Student.CourseID]
    FOREIGN KEY ([CourseID])
      REFERENCES [Course]([CourseID])
);

CREATE TABLE [HubSession] (
  [SessionID] INT,
  [TimeIn] DATETIME,
  [TimeOut] DATETIME,
  [StudentID] INT,
  [EmployeeID] INT,
  PRIMARY KEY ([sessionID]),
  CONSTRAINT [FK_HubSession.StudentID]
    FOREIGN KEY ([StudentID])
      REFERENCES [Student]([StudentID]),
  CONSTRAINT [FK_HubSession.EmployeeID]
    FOREIGN KEY ([EmployeeID])
      REFERENCES [HubEmployee]([EmployeeID])
);

CREATE TABLE [SecurityQuestion] (
  [QuestionID] INT,
  [Question] NVARCHAR(255),
  PRIMARY KEY ([QuestionID])
);

-- Insert sample data into Course, Instructor, and Student tables
INSERT INTO [Course] ([CourseID], [CourseName])
VALUES
    (1, '101'),
    (2, '102');

INSERT INTO [Instructor] ([InstructorID], [LastName], [FirstName])
VALUES
    (1, 'Rubin', 'Dr'),
    (2, 'Araujo', 'Ken');

INSERT INTO [Student] ([StudentID], [FirstName], [LastName], [CourseID], [InstructorID])
VALUES
    (1, 'John', 'Student', 1, 1),
    (2, 'Emily', 'Pizza', 2, 2);