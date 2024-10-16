using Domain.Entities.Security;
using Domain.Ports.Repository;
using System.Data;

namespace Infrastructura.Adapters.Repository;

public class AuthRepository(IDbConnection dbConnection, IDbTransaction dbTransaction)
    : ServiceRepository<User>(dbConnection, dbTransaction), IAuthRepository
{

    public async Task<bool> CreateUserCredentials(User user)
    {
        return await AddAsync(user); 
    }
    public async Task<User> ValidateUserCredentials(string userName, string password) {
        return await GetByFilterAsync(new User { Password = password, UserName = userName });
    }

    public async Task<User> GetUserCredentials(string userName)
    {
        return await GetByFilterAsync(new User { UserName = userName });
    }
    public  Task<bool> ChangeUserName(Guid id, string userName)
    {
        return UpdateAsync(new User { Id = id, UserName = userName });

    }

    public Task<bool> ChangePassword(Guid id, string newPassword)
    {
        return UpdateAsync(new User { Id = id, Password = newPassword });
    }

    public async Task<bool> DeteleUserCredentials(Guid id)
    {
        return await DeleteAsync(id);
    }

    public async Task<User> GetUserCredentials(Guid id)
    {
        return await GetByIdAsync(id);
    }

}

