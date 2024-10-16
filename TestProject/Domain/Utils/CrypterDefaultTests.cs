using Domain.Utils;

namespace TestProject.Domain.Ports;

[TestFixture]
public class CrypterDefaultTests
{
    [Test]
    public void EncriptText_WithStringValid_ReturnsString()
    {
        var stringValid = "";

        var result = CrypterDefault.Encrypt(stringValid);

        Assert.That(result, !Is.Null);
    }

    [Test]
    public void DesencriptText_WithStringValid_ReturnsString()
    {
        var stringValid = "";

        var result = CrypterDefault.Decrypt(stringValid);

        Assert.That(result, !Is.Null);
    }
}
