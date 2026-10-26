namespace Soccer.Application.Exceptions;

public class ValidationException(string message, string prop) : Exception(message)
{
    public string Property { get; protected set; } = prop;
}