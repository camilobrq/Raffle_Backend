using Domain.Entities.Security;
using Domain.Ports.Repository;
using System.Data;

namespace Infrastructura.Adapters.Repository;

public class SessionRepository(IDbConnection dbConnection, IDbTransaction dbTransaction) 
    : ServiceRepository<Session>(dbConnection, dbTransaction), ISessionRepository
{
    public async Task<bool> CreateUserSession(Session session)
    {
        return await this.AddAsync(session);
    }
    public async Task<bool> CloseUserSession(Guid id)
    {
        return await this.UpdateAsync(new Session { Id = id, EndTime = DateTime.UtcNow, Active = false});
    }

}
