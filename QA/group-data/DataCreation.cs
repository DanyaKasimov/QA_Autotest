using System.Xml.Serialization;
using NUnit.Framework;

namespace QA.group_data;

[TestFixture]
public class DataCreation : TestBase
{
    public static IEnumerable<Data>? GroupDataFromXmlFile()
    {
        return (List<Data>)new XmlSerializer(typeof(List<Data>))
            .Deserialize(new StreamReader(@"/Users/danilkasimov/RiderProjects/QA/QA/file/test"))!;
    }

    [Test, TestCaseSource("GroupDataFromXmlFile")]
    public void DataCreationTest(Data group)
    {
        app.createData(group);
    }
    
}
    