using System.Text;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using QA.helpers;

namespace QA;

public class ApplicationManager
{
    private IWebDriver driver;

    private NavigationHelper navigation;
    private LoginHelper auth;
    private EntityHelper entity;
    private Data Data;

    private String BASE_URL;

    private static ThreadLocal<ApplicationManager?>? app = new ThreadLocal<ApplicationManager?>();
    
    private ApplicationManager()
    {
        driver = new FirefoxDriver();
        BASE_URL = "https://health-diet.ru/";
        auth = new LoginHelper(this);
        entity = new EntityHelper(this);
        navigation = new NavigationHelper(this, BASE_URL);
    }


    public void createData(Data data)
    {   
        this.Data = data;
    }
    
    public static ApplicationManager? GetInstance()
    {
        if (!app.IsValueCreated)
        {
            ApplicationManager newInstance = new ApplicationManager();
            newInstance.Navigation.OpenHomePage();
            app.Value = newInstance;
        }

        return app.Value;
    }

    public IWebDriver Driver
    {
        get { return driver; }
    }

    public NavigationHelper Navigation
    {
        get { return navigation; }
    }

    public LoginHelper Auth
    {
        get { return auth; }
    }

    public EntityHelper Entity
    {
        get { return entity; }
    }

    public Data getData() => Data;
    
    ~ApplicationManager()
    {
        try
        {
            driver.Quit();
        }
        catch (Exception)
        {
            //ignore
        }
    }
}