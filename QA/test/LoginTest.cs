using NUnit.Framework;
using QA;

[TestFixture]
public class LoginTests : TestBase
{
    
    [SetUp]
    public void SetupTest()
    {
        app.Navigation.OpenHomePage();
    }
    
    [Test, Order(2)]
    public void LoginWithValidData()
    {
        app.Auth.Logout();
        var user = new AccountData(Settings.Login, Settings.Password);
        app.Auth.Login(user);
        Assert.IsTrue(app.Auth.IsLoggedIn("Даниил"));
    }

    [Test, Order(1)]
    public void LoginWithInvalidData()
    {
        app.Auth.Logout();
        var user = new AccountData("FakeUser", "FakePass");
        app.Auth.Login(user);
        Assert.IsFalse(app.Auth.IsLoggedIn("Даниил"));
    }
}