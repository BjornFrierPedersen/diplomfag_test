using SchoolApplication.Infrastructure;
using SchoolApplication.Models;

namespace SchoolApplication.Services;

public class EnrollmentService
{
    private readonly SchoolRepository _repository = new();
    public void ProcessEnrollmentCreation()
    {
        Console.WriteLine("Please input student id");
        var studentId = Console.ReadLine();
        Console.WriteLine("Please input course id");
        var courseId = Console.ReadLine();
        Console.WriteLine("Please input grade");
        var grade = Console.ReadLine();

        var parsedStudentId = studentId.TryParseToInt();
        var parsedCourseId = courseId.TryParseToInt();
        if (!ValidateInput(parsedStudentId, parsedCourseId, grade)) return;

        var student = _repository.GetStudentById(parsedStudentId);
        var course = _repository.GetCourseById(parsedCourseId);
        if (!ValidateEntites(student, course)) return;
        
        Console.WriteLine("You have chosen enrollment with:"
                .WithTab($"Student: {student}")
                .WithTab($"Course: {course}")
                .WithTab($"Grade: {grade}")
            .WithNewline("is this correct? y/n"));
        
        if (Console.ReadLine() != "y")
        {
            Console.WriteLine("Aborting changes...");
            return;
        }
        var enrollment = new Enrollment { StudentId = student!.Id, CourseId = course!.Id, Grade = grade!};
        var createdEnrollment = _repository.CreateEnrollment(enrollment);
        Console.WriteLine($"The enrollment {createdEnrollment} has been created to the database.");
    }

    private bool ValidateInput(int studentId, int courseId, string? grade)
    {
        List<(string, string)> invalidInput = new();
        
        if (studentId is 0) invalidInput.Add(($"Student id: {studentId}", "integer id"));
        if (courseId is 0) invalidInput.Add(($"Course id {courseId}", "integer id"));
        if (grade == null || grade.Length > 2) invalidInput.Add(($"Grade {grade ?? "null"}", "grade"));

        if (!invalidInput.Any()) return true;
        
        foreach (var (input,type) in invalidInput)
        {
            Console.WriteLine($"{input} is not a valid {type}.");
        }

        return false;
    }

    private bool ValidateEntites(Student? student, Course? course)
    {
        List<string> notFoundEntites = new();
        if(student == null) notFoundEntites.Add("Student");
        if(course == null) notFoundEntites.Add("Course");
        if (!notFoundEntites.Any()) return true;
        foreach (var entity in notFoundEntites)
        {
            Console.WriteLine($"{entity} was not found in the database.");
        }

        return false;
    }
    
}