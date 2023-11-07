using System.ComponentModel;
using SchoolApplication.Models;

namespace SchoolApplication.Infrastructure;

public static class CommandExtensions
{
    public static string AsString(this CommandEnum source)
    {
        var fi = source.GetType().GetField(source.ToString());
        if (fi == null) return source.ToString();
        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : source.ToString();
    } 
    
    public static CommandEnum TryParseCommand(this string? commandInput)
    {
        if (string.IsNullOrEmpty(commandInput))
        {
            Console.WriteLine("Please input a command");
            return CommandEnum.NotInitialized;
        }

        return Commands.CommandDictionary.FirstOrDefault(kv => kv.Value.Equals(commandInput)).Key;
    }
}