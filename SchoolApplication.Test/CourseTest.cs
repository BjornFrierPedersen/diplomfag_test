using SchoolApplication.Infrastructure;
using SchoolApplication.Models;
using SchoolApplication.Persistance;
using SchoolApplication.Test.Extensions;
using Xunit;

namespace SchoolApplication.Test;

[Collection(TestVariables.DatabaseCollection)]
public class CourseTest
{
    private SchoolDbContext _dbContext;
    private readonly SchoolRepository _repository = new();

    public CourseTest(DatabaseFixture fixture)
    {
        _dbContext = fixture.SchoolDbContext;
    }
    
    [Fact]
    public void Check_that_course_is_created_when_given_valid_input()
    {
        // Arrange
        var newCourse = new Course
        {
            Name = "Mathmatics",
            Credits = 10
        };
        
        // Act
        _repository.CreateCourse(newCourse);
        var course = _dbContext.Courses.OrderBy(course => course.Id).Last();

        // Assert
        course
            .ShouldExist()
            .WithName("Mathmatics")
            .WithCredits(10);
    }
}