using Drinks.Eddyfadeev.View;

namespace Drinks.Eddyfadeev.Exceptions;

/// <summary>
/// The class is used to throw an exception when the user wants to return to the previous menu.
/// </summary>
public class ReturnToPreviousMenuException : Exception
{
    public ReturnToPreviousMenuException() : base(Messages.ReturningToMainMenu)
    {
    }
    
    public ReturnToPreviousMenuException(string message) : base(message)
    {
    }
    
    public ReturnToPreviousMenuException(string message, Exception innerException) : base(message, innerException)
    {
    }
}