using Notes.Domain.Services.Base;
using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.Ports;

namespace Domain.Services;
[DomainService]
public class AuthService(IUnitOfWork _unitOfWork)
{
    public async Task<User> UserById(Guid id)
    {
        try
        {
            var user = await _unitOfWork.AuthRepository.GetUserCredentials(id)
                ?? throw new FailCredentialsException("Invalid refresh");
            _unitOfWork.SaveChanges();
            return user;
        }
        catch (Exception e)
        {
            _unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }
    public async Task<User> SignIn(string userName, string password, Guid sessionId)
    {
		try
		{
			var user = await _unitOfWork.AuthRepository.ValidateUserCredentials(userName, password) 
                ?? throw new FailCredentialsException("UserName or Password incorrect");
            var role = await _unitOfWork.RoleRepository.GetRoleById(user.RoleId) 
                ?? throw new NoContentException("Role No Defined");
            user.Role = role;

            var session = new Session
            {
                Active = true,  UserId = user.Id,
                StartTime = DateTime.UtcNow, Id = sessionId,
            };
            
            await _unitOfWork.SessionRepository.CreateUserSession(session);

            _unitOfWork.SaveChanges();
			return user;
        }
		catch(Exception e)
		{
			_unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }

    public async Task<User> SignUp(User user, string roleCode = "USER")
    {
        try
        {

            var findUser = await _unitOfWork.AuthRepository.GetUserCredentials(user.UserName);

            if(findUser != null)
            {
                throw new DuplicateCredentialsException("Email Exist");
            }

            var role = await _unitOfWork.RoleRepository.GetRoleByCode(roleCode)
                ?? throw new NoContentException("Role No Defined");

            user.RoleId = role.Id;

            await _unitOfWork.AuthRepository.CreateUserCredentials(user);

            _unitOfWork.SaveChanges();
            return user;
        }
        catch (Exception e)
        {
            _unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }

    public async Task SignOut(Guid sessionId)
    {
        try
        {
            await _unitOfWork.SessionRepository.CloseUserSession(sessionId);
            _unitOfWork.SaveChanges();
        }
        catch (Exception e)
        {
            _unitOfWork.Dispose();
            throw new Exception(e.Message);
        }
    }
}
