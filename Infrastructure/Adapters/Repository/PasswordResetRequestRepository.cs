using Domain.Entities.Security;
using Domain.Ports.Repository;
using Infrastructura.Adapters;
using System.Data;

namespace Infrastructure.Adapters.Repository;

public class PasswordResetRequestRepository(IDbConnection dbConnection, IDbTransaction dbTransaction)
    : ServiceRepository<PasswordResetRequest>(dbConnection, dbTransaction), IPasswordResetRequestRepository
{
    public Task<PasswordResetRequest> GetByResetCodeAsync(string resetCode)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<PasswordResetRequest>> GetByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> MarkAsUsedAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
