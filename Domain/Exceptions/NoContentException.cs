using System.Runtime.Serialization;

namespace Domain.Exceptions;

public class NoContentException : Exception
{
    public NoContentException(string message) : base(message)
    {
    }

    public NoContentException(string message, Exception inner) : base(message, inner)
    {
    }
}

