using SchoolApplication.Models;
using Xunit;

namespace SchoolApplication.Test.Extensions;

public static class CourseValidationExtensions
{
    public static Course ShouldExist(this Course course)
    {
        Assert.NotNull(course);
        return course;
    }

    public static Course WithName(this Course course, string expectedName)
    {
        Assert.Equal(expectedName, course.Name);
        return course;
    }
    
    public static Course WithCredits(this Course course, int expectedCredits)
    {
        Assert.Equal(expectedCredits, course.Credits);
        return course;
    }
}