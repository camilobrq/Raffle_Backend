namespace Infrastructure.Adapters.Jwt;

public class JwtSettings
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public double DurationInMinutesAccess { get; set; } = double.MinValue;
    public double DurationInMinutesRefresh { get; set; } = double.MinValue;
}