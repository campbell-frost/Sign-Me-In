using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Account
{
    [Key]
    public int AccountID { get; set; }
    public string? UserName { get; set; }
    public string? PasswordHash { get; set; }
    public bool IsLoggedIn { get; set; } 
}

public class HubEmployee
{
    [Key]
    public int EmployeeID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Initials { get; set; }
    public string? Role { get; set; }

    [ForeignKey("Account")]
    public int AccountID { get; set; }
    public Account? Account { get; set; }
}


public class SecurityQuestion
{
    [Key]
    public int QuestionID { get; set; }
    public string? Question { get; set; }

    [ForeignKey("Account")]
    public int AccountID { get; set; }
    public Account? Account { get; set; }

    public string? AnswerHash { get; set; } // Include this property for storing answers
}

public class Course
{
    [Key]
    public int CourseID { get; set; }
    public string? CourseName { get; set; }
}

public class Instructor
{
    [Key]
    public int InstructorID { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
}

public class Student
{
    [Key]
    public int StudentID { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    [ForeignKey("Course")]
    public int CourseID { get; set; }
    public Course? Course { get; set; }

    [ForeignKey("Instructor")]
    public int InstructorID { get; set; }
    public Instructor? Instructor { get; set; }
}

public class HubSession
{
    [Key]
    public int SessionID { get; set; }
    public DateTime Date {get; set;}
    public TimeSpan TimeIn { get; set; }
    public TimeSpan? TimeOut { get; set; }
    public string? SessionType {get; set; }

    [ForeignKey("Student")]
    public int StudentID { get; set; }
    public Student? Student { get; set; }

    [ForeignKey("HubEmployee")]
    public int EmployeeID { get; set; }
    public HubEmployee? HubEmployee { get; set; }
}

