-- Insert sample data into Course, Instructor, and Student tables
SET IDENTITY_INSERT [dbo].[Courses] ON
INSERT INTO [Courses] ([CourseID], [CourseName])
VALUES
    (1, '101'),
    (2, '102'),
    (3, '201'),
    (4, '202'),
    (5, '203'),
    (6, 'CPT 170');
SET IDENTITY_INSERT [dbo].[Courses] OFF

SET IDENTITY_INSERT [dbo].[Instructors] ON
INSERT INTO [Instructors] ([InstructorID], [LastName], [FirstName])
VALUES
    (1, 'Rubin', 'Steve'),
    (2, 'Araujo', 'Ken'),
    (3, 'Rao', 'Padmaja'),
    (4, 'Panza', 'Nicole'),
    (3, 'Dungan', 'Ivan');
SET IDENTITY_INSERT [dbo].[Instructors] OFF

SET IDENTITY_INSERT [dbo].[Students] ON

INSERT INTO [dbo].[Students] (StudentID, FirstName, LastName, CourseID, InstructorID)
VALUES 
    (1, 'Michael', 'Scott', 1, 1),
    (2, 'Jim', 'Halpert', 2, 2),
    (3, 'Pam', 'Beesly', 1, 2),
    (4, 'Dwight', 'Schrute', 1, 3), 
	  (5, 'Ryan', 'Howard', 3, 5),
    (6, 'Andy', 'Bernard', 4, 1),
    (7, 'Kelly', 'Kapoor', 3, 2),
    (8, 'Angela', 'Martin', 1, 3),
    (9, 'Oscar', 'Martinez', 2, 4),
    (10, 'Kevin', 'Malone', 1, 2),
    (11, 'Stanley', 'Hudson', 3, 4),
    (12, 'Phyllis', 'Smith', 2, 1),
    (13, 'Meredith', 'Palmer', 3, 2),
    (14, 'Creed', 'Bratton', 4, 3),
    (15, 'Toby', 'Flenderson', 2, 4),
    (16, 'Darryl', 'Philbin', 1, 5),
    (17, 'Jan', 'Levinson', 4, 1),
    (18, 'Roy', 'Anderson', 3, 5),
    (19, 'Karen', 'Filippelli', 2, 4),
    (20, 'Holly', 'Flax', 1, 3),
    (21, 'Erin', 'Hannon', 4, 2),
    (22, 'Gabe', 'Lewis', 2, 1),
    (23, 'Nellie', 'Bertram', 3, 3);

SET IDENTITY_INSERT [dbo].[Students] OFF


SET IDENTITY_INSERT [dbo].[Accounts] ON

INSERT INTO [dbo].[Accounts] ([AccountID], [UserName], [PasswordHash])
VALUES
	(1, 'Manager', 'admin'),
	(2, 'Staff', 'fdtcstaff');

SET IDENTITY_INSERT [dbo].[Accounts] OFF

SET IDENTITY_INSERT [dbo].[HubEmployees] ON

INSERT INTO [dbo].[HubEmployees] ([EmployeeID], [FirstName], [LastName], [Initials], [Role], [AccountID])
VALUES
  (1, 'Megan', 'Webster', 'MW', 'Tutor', 2),
	(2, 'Campbell', 'Frost', 'CF', 'Tester', 2),
  (2, 'Bhakti', 'Patel', 'BP', 'Tester', 2);

SET IDENTITY_INSERT [dbo].[HubEmployees] OFF