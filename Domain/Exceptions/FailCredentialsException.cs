using System.Runtime.Serialization;

namespace Domain.Exceptions;

public class FailCredentialsException : Exception
{
    public FailCredentialsException(string message) : base(message)
    {
    }

    public FailCredentialsException(string message, Exception inner) : base(message, inner)
    {
    }
}

