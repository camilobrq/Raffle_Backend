namespace Application.UseCase.Security.Authentication.Dtos;

public class AuthenticationDto
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}
