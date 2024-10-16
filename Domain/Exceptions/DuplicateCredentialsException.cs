using System.Runtime.Serialization;

namespace Domain.Exceptions;

public class DuplicateCredentialsException: Exception
{
    public DuplicateCredentialsException(string message) : base(message)
    {
    }

    public DuplicateCredentialsException(string message, Exception inner) : base(message, inner)
    {
    }
}

