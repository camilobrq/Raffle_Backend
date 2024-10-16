using Domain.Entities.Security;

namespace Domain.Ports.Repository;

public interface IAuthRepository: IGenericRepository<User>
{
    public Task<User> ValidateUserCredentials(string userName, string password);
    public Task<bool> ChangePassword(Guid id, string newPassword);
    public Task<bool> ChangeUserName(Guid id, string userName);
    public Task<bool> CreateUserCredentials(User user);
    public Task<User> GetUserCredentials(Guid id);
    public Task<User> GetUserCredentials(string userName);
    public Task<bool> DeteleUserCredentials(Guid id);
}
