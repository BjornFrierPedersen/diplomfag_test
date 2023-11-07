using SchoolApplication.Infrastructure;

namespace SchoolApplication.Services;

public class SchoolService
{
    private readonly SchoolRepository _repository = new();

    public void MigrateDatabase()
    {
        _repository.MigrateDatabase();
        Console.WriteLine(
            "The database has been successfully updated with the newest migrations.");
    }
    
    public void CleanDatabase()
    {
        Console.WriteLine("You are about to delete all data from the database, are you sure? y/n");
        if (Console.ReadLine() != "y") return;
        _repository.CleanDatabase();
        Console.WriteLine(
            "The database has been cleaned.");
    }
}