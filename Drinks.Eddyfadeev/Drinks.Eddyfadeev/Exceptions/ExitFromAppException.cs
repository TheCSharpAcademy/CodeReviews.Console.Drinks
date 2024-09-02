using Drinks.Eddyfadeev.View;

namespace Drinks.Eddyfadeev.Exceptions;

/// <summary>
/// The class is used to throw an exception when the application is exiting.
/// </summary>
public class ExitApplicationException : Exception
{
    public ExitApplicationException() : base(Messages.ExitingApplication)
    {
    }
    
    public ExitApplicationException(string message) : base(message)
    {
    }
    
    public ExitApplicationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}