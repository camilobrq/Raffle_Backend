using Domain.Entities.Base;
using System.Text.Json.Serialization;

namespace Domain.Entities.Security;

public class User : EntityBase
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Guid RoleId { get; set; }
    public Role Role { get; set; } = new(); 
}
