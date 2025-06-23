
using NUnit.Framework;

namespace QA
{
    public class AuthBase : TestBase
    {
        protected AccountData user;

        [SetUp]
        public void AuthSetUp()
        {
            user = new AccountData(Settings.Login, Settings.Password);
            app?.Navigation.OpenHomePage();
            app?.Navigation.ManageWindow(1197, 724);
            app?.Auth.Login(user);
        }
    }
}
