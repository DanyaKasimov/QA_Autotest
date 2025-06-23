namespace QA;


using NUnit.Framework;

public class TestBase
{
    protected ApplicationManager? app;

    [SetUp]
    public void SetupTest()
    {
        app = ApplicationManager.GetInstance();
    }
    
}