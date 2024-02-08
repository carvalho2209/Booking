namespace Booky.Application.Exceptions;

public class ConcurrencyException : Exception
{
    /// <inheritdoc />
    public ConcurrencyException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}