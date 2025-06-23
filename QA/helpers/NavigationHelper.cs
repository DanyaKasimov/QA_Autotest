using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace QA.helpers;

public class NavigationHelper: HelperBase
{
    
    private String baseURL;
    public NavigationHelper(ApplicationManager manager, String baseUrl) : base(manager) 
    {
        baseURL = baseUrl;
    }
    
    public void OpenHomePage()
    {
        driver.Navigate().GoToUrl(baseURL);
    }

    public void ManageWindow(int width, int height)
    {
        driver.Manage().Window.Size = new System.Drawing.Size(width, height);
        {
            var element = driver.FindElement(By.CssSelector(".uk-width-medium-1-3:nth-child(2) .uk-position-top-left"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }
    }

}