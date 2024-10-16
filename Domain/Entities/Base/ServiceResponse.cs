
namespace Domain.Entities.Base;

public class ServiceResponse<T>(string message, T data, bool success) : ServiceResponse(message,success)
{
    public new string Message { get; set; } = message;
    public new bool Success { get; set; } = success;
    public T Data { get; set; } = data;
}

public class ServiceResponse(string message, bool success)
{
    public string Message { get; set; } = message;
    public bool Success { get; set; } = success;
}
