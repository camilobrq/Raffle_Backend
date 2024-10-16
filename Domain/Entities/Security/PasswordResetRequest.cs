using Domain.Entities.Base;

namespace Domain.Entities.Security;

public class PasswordResetRequest: IEntityBase<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string UserId { get; set; } = string.Empty;
    public string ResetCode { get; set; } = string.Empty;
    public DateTime ExpirationDate { get; set; }
    public bool Used { get; set; } = false;

}
