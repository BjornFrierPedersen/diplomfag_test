using SchoolApplication.Infrastructure;
using SchoolApplication.Models;

namespace SchoolApplication.Services;

public class CourseService
{
    private readonly SchoolRepository _repository = new();
    public void ProcessCourseCreation()
    {
        Console.WriteLine("Please input course name");
        var courseName = Console.ReadLine();
        Console.WriteLine("Please input amount of credits");
        var credits = Console.ReadLine();
        Console.WriteLine($"You have inputted course name: {courseName} with credits: {credits}. is this correct? y/n");
        if (Console.ReadLine() != "y")
        {
            Console.WriteLine("Aborting changes.");
            return;
        }

        var wasCreditsParsed = int.TryParse(credits, out var parsedCredits);
        var course = new Course { Name = courseName ?? String.Empty, Credits = wasCreditsParsed ? parsedCredits : 10 /*defaultAmount*/ };
        var createdCourse = _repository.CreateCourse(course);
        Console.WriteLine($"The course {createdCourse} has been created to the database.");
    }
}