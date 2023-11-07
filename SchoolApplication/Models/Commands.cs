using System.ComponentModel;
using SchoolApplication.Infrastructure;

namespace SchoolApplication.Models;

public static class Commands
{
    public static readonly Dictionary<CommandEnum, string> CommandDictionary = new()
    {
            { CommandEnum.ApplyMigrations, "--db-update" },
            { CommandEnum.CleanDatabase, "--db-clean" },
            { CommandEnum.CreateNewStudent, "--create-student" },
            { CommandEnum.CreateNewCourse, "--create-course" },
            { CommandEnum.CreateNewEnrollment, "--create-enrollment" },
            { CommandEnum.ExitProgram, "/exit" },
            { CommandEnum.Help, "/help" },
            { CommandEnum.Clear, "clear" }
        };

    private static readonly KeyValuePair<CommandEnum, string>[] CommandDictionaryArray = CommandDictionary.ToArray();

    public static string GetCommandSelection => string.Empty
    .WithNewline("Database specific commands:")
        .WithTab(CommandDictionaryArray[0]) // DbUpdate
        .WithTab(CommandDictionaryArray[1]) // DbClean
    .WithNewline("Domain specific commands:")
        .WithTab(CommandDictionaryArray[2]) // CreateStudent
        .WithTab(CommandDictionaryArray[3]) // CreateCourse
        .WithTab(CommandDictionaryArray[4]) // CreateEnrollment
    .WithNewline("Application specific commands")
        .WithTab(CommandDictionaryArray[5]) // Exit
        .WithTab(CommandDictionaryArray[6]); // Help
}

public enum CommandEnum
{
    NotInitialized,
    [Description("Apply Migrations")]
    ApplyMigrations,
    [Description("Clean Database")]
    CleanDatabase,
    [Description("Create new Student")]
    CreateNewStudent,
    [Description("Create new Course")]
    CreateNewCourse,
    [Description("Create new Enrollment")]
    CreateNewEnrollment,
    [Description("Exit the program")]
    ExitProgram,
    [Description("Get list of commands")]
    Help,
    Clear
}