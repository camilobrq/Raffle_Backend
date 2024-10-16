using Domain.Entities.Security;

namespace Domain.Ports.Repository;

public interface ISessionRepository: IGenericRepository<Session>
{
    public Task<bool> CreateUserSession(Session session);
    public Task<bool> CloseUserSession(Guid id);

}
