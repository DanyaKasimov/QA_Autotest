using OpenQA.Selenium;

namespace QA;

public class HelperBase
{
    protected IWebDriver driver;

    protected ApplicationManager app;
    
    public HelperBase(ApplicationManager manager)
    {
        driver = manager.Driver;
        app = manager;
    }
}