using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<HubEmployee> HubEmployees { get; set; }
    public DbSet<SecurityAnswers> SecurityAnswers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<HubSession> HubSessions { get; set; }
    public DbSet<SecurityQuestion> SecurityQuestions { get; set; }
}
