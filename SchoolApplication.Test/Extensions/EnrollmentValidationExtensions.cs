using SchoolApplication.Models;
using Xunit;

namespace SchoolApplication.Test.Extensions;

public static class EnrollmentValidationExtensions
{
    public static Enrollment ShouldExist(this Enrollment enrollment)
    {
        Assert.NotNull(enrollment);
        return enrollment;
    }
    
    public static Enrollment ForStudent(this Enrollment enrollment, int expectedStudentId)
    {
        Assert.Equal(expectedStudentId, enrollment.StudentId);
        return enrollment;
    }
    
    public static Enrollment ForCourse(this Enrollment enrollment, int expectedCourseId)
    {
        Assert.Equal(expectedCourseId, enrollment.CourseId);
        return enrollment;
    }

    public static Enrollment WithGrade(this Enrollment enrollment, string expectedGrade)
    {
        Assert.Equal(expectedGrade, enrollment.Grade);
        return enrollment;
    }
}