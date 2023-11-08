using SchoolApplication.Models;
using Xunit;

namespace SchoolApplication.Test.Extensions;

public static class StudentValidationExtensions
{
    public static Student ShouldExist(this Student student)
    {
        Assert.NotNull(student);
        return student;
    }

    public static Student WithFullname(this Student student, string expectedFullName)
    {
        var actualFullname = $"{student.FirstName} {student.LastName}";
        Assert.Equal(expectedFullName, actualFullname);
        return student;
    }
}