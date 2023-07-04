namespace BoundlessBook.Common.Common.Domain.Exceptions;

public class NullOrEmptyDomainException : Exception
{
    public NullOrEmptyDomainException()
    {

    }

    public NullOrEmptyDomainException(string message) : base(message)
    {

    }

    public static void CheckString(string value, string nameOfField)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new NullOrEmptyDomainException($"{nameOfField} is null or empty");
    }
}