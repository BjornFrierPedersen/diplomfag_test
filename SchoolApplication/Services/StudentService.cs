using SchoolApplication.Infrastructure;
using SchoolApplication.Models;

namespace SchoolApplication.Services;

public class StudentService
{
    private readonly SchoolRepository _repository = new();
    public void ProcessStudentCreation()
    {
        Console.WriteLine("Please input first name");
        var firstname = Console.ReadLine();
        Console.WriteLine("Please input last name");
        var lastname = Console.ReadLine();
        Console.WriteLine($"You have inputted name: {firstname} {lastname} is this correct? y/n");
        if (Console.ReadLine() != "y")
        {
            Console.WriteLine("Aborting changes...");
            return;
        }
        var student = new Student { FirstName = firstname ?? String.Empty, LastName = lastname ?? String.Empty };
        var createdStudent = _repository.CreateStudent(student);
        Console.WriteLine($"The student {createdStudent} has been created to the database.");
    }
}