using SchoolApplication.Infrastructure;
using SchoolApplication.Models;
using SchoolApplication.Persistance;

namespace SchoolApplication.Test;

public class TestDataBuilder
{
    private readonly SchoolDbContext _dbContext;
    private readonly SchoolRepository _repository = new ();

    public TestDataBuilder(SchoolDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CleanDatabase() => _repository.CleanDatabase();
    

    public void SeedDefaultData()
    {
        this
            .WithStudent("John", "Doe", out var johnKey)
            .WithStudent("Jane", "Smith", out var janeKey)
            .WithStudent("Alice", "Johnson", out var aliceKey)
            .WithCourse("Mathmatics", 3, out var mathmaticsKey)
            .WithCourse("Physics", 4, out var physicsKey)
            .WithCourse("Chemistry", 3, out var chemistryKey)
            .WithEnrollment(johnKey, mathmaticsKey, "A")
            .WithEnrollment(johnKey, physicsKey, "B")
            .WithEnrollment(janeKey, mathmaticsKey, "C")
            .WithEnrollment(aliceKey, chemistryKey, "A")
            .Build();
    }

    public TestDataBuilder WithStudent(string firstName, string lastname, out int studentId)
    {
        var student = _dbContext.Students.Add(new Student { FirstName = firstName, LastName = lastname }).Entity;
        _dbContext.SaveChanges();
        studentId = student.Id;
        return this;
    }
    
    public TestDataBuilder WithCourse(string name, int credits, out int courseId)
    {
        var course = _dbContext.Courses.Add(new Course { Name = name, Credits = credits }).Entity;
        _dbContext.SaveChanges();
        courseId = course.Id;
        return this;
    }

    public TestDataBuilder WithEnrollment(int studentId, int courseId, string grade)
    {
        if (grade.Length is < 1 or > 2) throw new ApplicationException("Grade must be either one or two characters long");
        
        _dbContext.Enrollments.Add(new Enrollment { StudentId = studentId, CourseId = courseId, Grade = grade });
        return this;
    }

    public TestDataBuilder Build()
    {
        _dbContext.SaveChanges();
        return this;
    }
    
    
    
}