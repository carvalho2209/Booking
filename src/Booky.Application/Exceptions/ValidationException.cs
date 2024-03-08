namespace Booky.Application.Exceptions;

public class ValidationException : Exception
{
    /// <inheritdoc />
    public ValidationException(IEnumerable<ValidationError> errors) => Errors = errors;

    public IEnumerable<ValidationError> Errors { get; }
}