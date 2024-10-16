using System.Runtime.Serialization;

namespace Domain.Exceptions;

public class IncorrectCredentialsException : Exception
{
    public IncorrectCredentialsException(string message) : base(message)
    {
    }

    public IncorrectCredentialsException(string message, Exception inner) : base(message, inner)
    {
    }
}

