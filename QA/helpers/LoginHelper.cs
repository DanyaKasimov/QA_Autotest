using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QA
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public bool IsLoggedIn()
        {
            return driver.FindElements(By.LinkText("Войти")).Count == 0;
        }

        public bool IsLoggedIn(string username)
        {
            if (!IsLoggedIn())
                return false;

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                wait.Until(drv => drv.FindElements(By.CssSelector("a.el-user")).Any());
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

            var elements = driver.FindElements(By.CssSelector("a.el-user"));
            foreach (var e in elements)
            {
                if (
                    e.Text.Trim().Equals(username, StringComparison.OrdinalIgnoreCase) ||
                    (e.GetAttribute("title")?.Trim().Equals(username, StringComparison.OrdinalIgnoreCase) ?? false)
                )
                    return true;
            }
            return false;
        }

        public void Login(AccountData user)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(user.Username))
                {
                    return;
                }
                Logout();
            }
            driver.FindElement(By.LinkText("Войти")).Click();
            driver.FindElement(By.Id("login")).Clear();
            driver.FindElement(By.Id("login")).SendKeys(user.Username);
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(user.Password);
            driver.FindElement(By.Name("button")).Click();
        }

        public void Logout()
        {
            // Клик по профилю -> выход
            if (!IsLoggedIn()) return;
            driver.FindElement(By.CssSelector(".uk-navbar-nav .uk-text-bold")).Click();
            driver.FindElement(By.LinkText("Выйти")).Click();
        }
    }
}