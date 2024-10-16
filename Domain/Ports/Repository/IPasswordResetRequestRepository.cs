using Domain.Entities.Security;

namespace Domain.Ports.Repository;

public interface IPasswordResetRequestRepository
{
    Task<PasswordResetRequest> GetByResetCodeAsync(string resetCode);
    Task<IEnumerable<PasswordResetRequest>> GetByUserIdAsync(Guid userId);
    Task<bool> MarkAsUsedAsync(Guid id);
}
