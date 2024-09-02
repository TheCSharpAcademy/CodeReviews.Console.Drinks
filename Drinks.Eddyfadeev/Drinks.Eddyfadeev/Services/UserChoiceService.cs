using Spectre.Console;

namespace Drinks.Eddyfadeev.Services;

/// <summary>
/// The UserChoiceService class provides methods for retrieving user input from the console.
/// </summary>
public static class UserChoiceService
{
    /// <summary>
    /// The GetUserInput method is responsible for retrieving user input from the console.
    /// </summary>
    /// <typeparam name="T">The type of the user input value.</typeparam>
    /// <param name="message">The message to display to the user before requesting input.</param>
    /// <returns>The user input value of type T.</returns>
    public static T GetUserInput<T>(string message)
    {
        var userInput = AnsiConsole.Ask<T>(message);
        
        return userInput;
    }
}