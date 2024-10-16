using Domain.Entities.Security;
using Domain.Exceptions;
using Domain.Services;

namespace TestProject.Domain.Ports;

[TestFixture]
public class AuthServiceTests
{
    private Mock<AuthService> _mockAuthServices;

    [SetUp]
    public void Setup()
    {
        _mockAuthServices = new Mock<AuthService>();
    }

    [Test]
    public async Task SingIn_WithValidUserNameAndPassword_ReturnsUser()
    {
        string userName = "thisUser", password = "thisPasssword";

        User expectedUser = new()
        {
            UserName = userName,
            Password = password,
            CreatedOn = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            State = true
        };

        _mockAuthServices.Setup(repo => repo.SignIn(userName, password, It.IsAny<Guid>()))
                       .ReturnsAsync(expectedUser);

        var result = await _mockAuthServices.Object.SignIn(userName, password, It.IsAny<Guid>());
        Assert.That(result.Password, Is.EqualTo(expectedUser.Password));
        _mockAuthServices.Verify(repo => repo.SignIn(userName, password, It.IsAny<Guid>()), Times.Once);
    }

    [Test]
    public void SingIn_WithInvalidUserNameAndPassword_ReturnsFailCredentialsException()
    {
        string strngException = "UserName or Password incorrect";
        FailCredentialsException failCredentials = new(strngException);

        _mockAuthServices.Setup(repo => repo.SignIn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Guid>()))
            .ThrowsAsync(failCredentials);

        var exception = Assert.ThrowsAsync<FailCredentialsException>(async () => 
        await _mockAuthServices.Object.SignIn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Guid>()));

        Assert.That(exception.Message, Is.EqualTo(strngException));

        _mockAuthServices.Verify(repo => repo.SignIn(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Guid>()), Times.Once);
    }

}
