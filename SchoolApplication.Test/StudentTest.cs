using SchoolApplication.Infrastructure;
using SchoolApplication.Models;
using SchoolApplication.Persistance;
using SchoolApplication.Test.Extensions;
using Xunit;

namespace SchoolApplication.Test;

[Collection(TestVariables.DatabaseCollection)]
public class StudentTest
{
    private SchoolDbContext _dbContext;
    private readonly SchoolRepository _repository = new();

    public StudentTest(DatabaseFixture fixture)
    {
        _dbContext = fixture.SchoolDbContext;
    }
    
    [Fact]
    public void Check_that_student_is_created_when_given_valid_input()
    {
        // Arrange
        var newStudent = new Student
        {
            FirstName = "Bob",
            LastName = "Strauss"
        };
        
        // Act
        _repository.CreateStudent(newStudent);
        var student = _dbContext.Students.OrderBy(student => student.Id).Last();

        // Assert
        student
            .ShouldExist()
            .WithFullname("Bob Strauss");
    }
}