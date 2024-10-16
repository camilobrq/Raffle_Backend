using Domain.Ports.Repository;

namespace Domain.Ports;

public interface IUnitOfWork
{
    IAuthRepository AuthRepository { get; }
    IProductRepository ProductRepository { get; }
    IServiceRepository ServiceRepository { get; }
    ISessionRepository SessionRepository { get; }
    IRoleRepository RoleRepository { get; }
    void SaveChanges();
    void Dispose();
}
