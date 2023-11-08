using SchoolApplication.Infrastructure;
using SchoolApplication.Models;
using SchoolApplication.Persistance;
using SchoolApplication.Test.Extensions;
using Xunit;

namespace SchoolApplication.Test;

[Collection(TestVariables.DatabaseCollection)]
public class EnrollmentTest
{
    private TestDataBuilder _builder;
    private SchoolDbContext _dbContext;
    private readonly SchoolRepository _repository = new();

    public EnrollmentTest(DatabaseFixture fixture)
    {
        _builder = fixture.Builder;
        _dbContext = fixture.SchoolDbContext;
    }
    
    [Fact]
    public void Check_that_enrollment_is_created_when_given_valid_input()
    {
        // Arrange
        _builder
            .WithStudent("Bob", "Strauss", out int studentId)
            .WithCourse("Mathmatics", 10, out int courseId)
            .Build();
        
        var newEnrollment = new Enrollment
        {
            StudentId = studentId,
            CourseId = courseId,
            Grade = "A"
        };
        
        // Act
        _repository.CreateEnrollment(newEnrollment);
        var enrollment = _dbContext.Enrollments.OrderBy(enrollment => enrollment.Id).Last();

        // Assert
        enrollment
            .ShouldExist()
            .ForStudent(studentId)
            .ForCourse(courseId)
            .WithGrade("A");
    }
}