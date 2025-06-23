using NUnit.Framework;
using OpenQA.Selenium;
using QA;
using System.Xml.Serialization;

[TestFixture]
public class TestTest : AuthBase
{
    public static IEnumerable<Data> GroupDataFromXmlFile()
    {
        return (List<Data>)new XmlSerializer(typeof(List<Data>))
            .Deserialize(new StreamReader(@"/Users/danilkasimov/RiderProjects/QA/QA/file/test.xml"))!;
    }

    [Test, TestCaseSource(nameof(GroupDataFromXmlFile)), Order(2)]
    public void UnitTestSendPostAndEdit(Data data)
    {
        app?.createData(data);
        app?.Entity.SendPost();

        var input = app?.Driver.FindElement(By.CssSelector(".uk-flex:nth-child(2) > .uk-flex > .uk-flex > .InputNumber"));
        Assert.AreEqual(data.value, input?.GetAttribute("value"), "Введённое значение не совпадает с ожидаемым из данных.");
        
        app?.Entity.Edit();

        Assert.AreEqual(data.value, input?.GetAttribute("value"), "Введённое значение в поле не равно 80 после редактирования.");
    }
    
}