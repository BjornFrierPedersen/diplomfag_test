using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SchoolApplication.Models;
using SchoolApplication.Persistance;

namespace SchoolApplication.Infrastructure;

public class SchoolRepository
{
    public Student? GetStudentById(int id)
    {
        using var dbContext = new SchoolDbContext();
        var student = dbContext.Students.FirstOrDefault(student => student.Id.Equals(id));
        return student;
    }
    
    public Course? GetCourseById(int id)
    {
        using var dbContext = new SchoolDbContext();
        var course = dbContext.Courses.FirstOrDefault(course => course.Id.Equals(id));
        return course;
    }
    
    public void MigrateDatabase()
    {
        using var dbContext = new SchoolDbContext();
        dbContext.Database.Migrate();
    }
    
    public void CleanDatabase()
    {
        using var dbContext = new SchoolDbContext();
        dbContext.Database.ExecuteSqlRaw("TRUNCATE \"Students\",\"Courses\",\"Enrollments\" RESTART IDENTITY CASCADE");
    }

    public Student CreateStudent(Student student)
    {
        using var dbContext = new SchoolDbContext();
        var createdStudent = dbContext.Students.Add(student);
        dbContext.SaveChanges();
        return createdStudent.Entity;
    }

    public Course CreateCourse(Course course)
    {
        using var dbContext = new SchoolDbContext();
        var createdCourse = dbContext.Courses.Add(course);
        dbContext.SaveChanges();
        return createdCourse.Entity;
    }

    public Enrollment CreateEnrollment(Enrollment enrollment)
    {
        using var dbContext = new SchoolDbContext();
        var createdEnrollment = dbContext.Enrollments.Add(enrollment);
        dbContext.SaveChanges();
        return createdEnrollment.Entity;
    }
}