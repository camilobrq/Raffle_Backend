using Domain.Entities.Base;

namespace Domain.Entities.Security;

public class Role: EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
