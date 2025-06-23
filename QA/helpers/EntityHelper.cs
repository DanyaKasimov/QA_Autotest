using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace QA;

public class EntityHelper : HelperBase
{
    public EntityHelper(ApplicationManager manager) : base(manager)
    {
    }
    
    public void SendPost()
    {
        var value = app.getData().value;
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(drv => drv.FindElement(By.CssSelector(".mzr-left-menu-items")));

        driver.FindElement(By.CssSelector(".mzr-left-menu-items")).Click();
        driver.FindElement(By.CssSelector(".mzr-left-menu-item:nth-child(3) > .uk-width-100")).Click();
        WebDriverWait wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        IWebElement input = wait2.Until(drv =>
            drv.FindElement(By.CssSelector(".uk-flex:nth-child(2) > .uk-flex > .uk-flex > .InputNumber"))
        );
        new Actions(driver).DoubleClick(input).Perform();
        input.SendKeys(Keys.Control + "a"); 
        input.SendKeys(Keys.Delete);       
        input.SendKeys(value);          
        input.SendKeys(Keys.Enter); 
    }

    public void Edit()
    {
        var value = app.getData().value;
        {
            var element = driver.FindElement(By.CssSelector(".mzr-left-menu-item:nth-child(6) > .uk-width-100"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element).Perform();
        }
        {
            var element = driver.FindElement(By.TagName("body"));
            Actions builder = new Actions(driver);
            builder.MoveToElement(element, 0, 0).Perform();
        }

        driver.FindElement(By.CssSelector(".mzr-left-menu-items")).Click();
        driver.FindElement(By.CssSelector(".mzr-left-menu-item:nth-child(3) > .uk-width-100")).Click();

        var input = driver.FindElement(By.CssSelector(".uk-flex:nth-child(2) > .uk-flex > .uk-flex > .InputNumber"));

        new Actions(driver).DoubleClick(input).Perform();
        input.SendKeys(Keys.Control + "a"); 
        input.SendKeys(Keys.Delete);        
        input.SendKeys(value);         
        input.SendKeys(Keys.Enter);       
    }
}