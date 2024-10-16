using Domain.Ports;
using Domain.Ports.Repository;
using Infrastructura.Adapters.Repository;
using Infrastructure.Adapters.Repository;
using System.Data;

namespace Infrastructura.Adapters;

public class UnitOfWork: IUnitOfWork, IDisposable
{
    private readonly IDbConnection _dbConnection;
    private IDbTransaction _dbTransaction;
    public IAuthRepository AuthRepository { get; }
    public IProductRepository ProductRepository { get; }
    public IServiceRepository ServiceRepository { get; }
    public ISessionRepository SessionRepository { get; }
    public IRoleRepository RoleRepository { get; }


    public UnitOfWork(IDbConnection dbConnection, IServiceRepository serviceRepository)
    {
        _dbConnection = dbConnection;
        _dbConnection.Open();
        _dbTransaction = _dbConnection.BeginTransaction();
        AuthRepository = new AuthRepository(_dbConnection, _dbTransaction);
        ProductRepository = new ProductRepository(_dbConnection, _dbTransaction);
        ServiceRepository = serviceRepository;
        SessionRepository = new SessionRepository(_dbConnection, _dbTransaction);
        RoleRepository = new RoleRepository(_dbConnection, _dbTransaction);
    }

    public void SaveChanges()
    {
        try
        {
            _dbTransaction.Commit();
        }
        catch
        {
            _dbTransaction.Rollback();
            throw;
        }
        finally
        {
            _dbTransaction.Dispose();
            _dbTransaction = _dbConnection.BeginTransaction();
        }
    }

    public void Dispose()
    {
        _dbTransaction?.Dispose();
        _dbConnection?.Dispose();
        GC.SuppressFinalize(this);
    }
}
