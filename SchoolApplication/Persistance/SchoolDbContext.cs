using Microsoft.EntityFrameworkCore;
using SchoolApplication.Models;

namespace SchoolApplication.Persistance;

public class SchoolDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5436;Database=SchoolDB;Username=postgres;Password=password");
}