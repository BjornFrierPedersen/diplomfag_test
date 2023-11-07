using System.Reflection;
using SchoolApplication.Models;

namespace SchoolApplication.Infrastructure;

public static class StringExtensions
{
    public static string WithNewline(this string source, string input) => source + $"\n{input}";

    public static string WithNewline(this string source, KeyValuePair<CommandEnum, string> input) =>
        source + $"\n{input.Key.AsString()}: {input.Value}";
    
    public static string WithTab(this string source, string input) => source + $"\n\t{input}";

    public static string WithTab(this string source, KeyValuePair<CommandEnum, string> input) =>
        source + $"\n\t{input.Key.AsString()}: {input.Value}";

    public static int TryParseToInt(this string? source)
    {
        var canParse = int.TryParse(source, out var value);
        if (canParse) return value;
        
        Console.WriteLine($"{source} is not a valid integer");
        return 0;

    }
}