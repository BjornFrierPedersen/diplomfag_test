using SchoolApplication.Infrastructure;
using SchoolApplication.Models;
using SchoolApplication.Services;

var schoolService = new SchoolService();
var studentService = new StudentService();
var courseService = new CourseService();
var enrollmentService = new EnrollmentService();

var canParseCommand = false;
var parsedCommand = CommandEnum.NotInitialized;
var commandRunSuccessfully = false;
var exitProgram = false;

Console.WriteLine("Please choose a command:".WithNewline(Commands.GetCommandSelection));

while (!exitProgram)
{
    ValidateCommand();
    ExecuteCommand();
    ResetCommandState();
}

void ExecuteCommand()
{
    while (!commandRunSuccessfully)
    {
        switch (parsedCommand)
        {
            case CommandEnum.ApplyMigrations:
                schoolService.MigrateDatabase();
                commandRunSuccessfully = true;
                break;
            case CommandEnum.CleanDatabase:
                schoolService.CleanDatabase();
                commandRunSuccessfully = true;
                break;
            case CommandEnum.CreateNewStudent:
                studentService.ProcessStudentCreation();
                commandRunSuccessfully = true;
                break;
            case CommandEnum.CreateNewCourse:
                courseService.ProcessCourseCreation();
                commandRunSuccessfully = true;
                break;
            case CommandEnum.CreateNewEnrollment:
                enrollmentService.ProcessEnrollmentCreation();
                commandRunSuccessfully = true;
                break;
            case CommandEnum.Help:
                Console.WriteLine(Commands.GetCommandSelection);
                commandRunSuccessfully = true;
                break;
            case CommandEnum.Clear:
                Console.Clear();
                commandRunSuccessfully = true;
                break;
            case CommandEnum.ExitProgram:
                commandRunSuccessfully = true;
                exitProgram = true;
                Console.WriteLine("shutting down...");
                break;
            case CommandEnum.NotInitialized:
                throw new ApplicationException("The command was not initialized properly, aborting...");
        }
    }
}

void ValidateCommand()
{
    while (!canParseCommand)
    {
        var command = Console.ReadLine();
        var parsedCommandValue = command.TryParseCommand();
        if (parsedCommandValue != CommandEnum.NotInitialized)
        {
            parsedCommand = parsedCommandValue;
            canParseCommand = true;
        }
        else
        {
            Console.WriteLine($"Error - command {command} not known, type /help for a list of commands");
        }
    }
}

void ResetCommandState()
{
    commandRunSuccessfully = false;
    canParseCommand = false;
    parsedCommand = CommandEnum.NotInitialized;
}



                  