-- Insert all the database tables

CREATE TABLE Account (
    AccountID INT PRIMARY KEY,
    UserName VARCHAR(255),
    PasswordHash VARCHAR(255)
);

CREATE TABLE HubEmployee (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Initials VARCHAR(255),
    Role VARCHAR(255),
    AccountID INT,
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);

CREATE TABLE SecurityQuestion (
    QuestionID INT PRIMARY KEY,
    Question VARCHAR(255),
    AccountID INT,
    AnswerHash VARCHAR(255),
    FOREIGN KEY (AccountID) REFERENCES Account(AccountID)
);

CREATE TABLE Course (
    CourseID INT PRIMARY KEY,
    CourseName VARCHAR(255)
);

CREATE TABLE Instructor (
    InstructorID INT PRIMARY KEY,
    LastName VARCHAR(255),
    FirstName VARCHAR(255)
);

CREATE TABLE Student (
    StudentID INT PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    CourseID INT,
    InstructorID INT,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (InstructorID) REFERENCES Instructor(InstructorID)
);

CREATE TABLE HubSession (
    SessionID INT PRIMARY KEY,
    Date DATE,
    TimeIn TIME,
    TimeOut TIME,
    SessionType VARCHAR(255),
    StudentID INT,
    EmployeeID INT,
    FOREIGN KEY (StudentID) REFERENCES Student(StudentID),
    FOREIGN KEY (EmployeeID) REFERENCES HubEmployee(EmployeeID)
);
