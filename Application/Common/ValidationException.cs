namespace Application.Common;

public class ValidationException(IEnumerable<string> failures) : Exception
{
    public List<string> Errors { get; } = failures.ToList();
}
