using System.Xml.Serialization;
using Generator.dto;

namespace Generator.generator;

class Program
{
    static void Main(string[] args)
    {
        int count;

        if (args.Length < 4)
        {
            Console.WriteLine("Введите количество объектов:");
            count = int.Parse(Console.ReadLine());
        }
        else
        {
            count = int.Parse(args[0]);
        }

        List<Data> groups = new List<Data>();
        for (int i = 0; i < count; i++)
        {
            groups.Add(new Data(
                GenerateTwoDigitNumberString()
            ));
        }

        {
            string fullPath = $"/Users/danilkasimov/RiderProjects/QA/QA/file/test.xml";
            WriteToXmlFile(groups, fullPath);
            Console.WriteLine($"Данные записаны в файл {Path.GetFullPath(fullPath)}");
        }
    }

    static string GenerateTwoDigitNumberString()
    {
        var rnd = new Random();
        return rnd.Next(10, 100).ToString(); 
    }

    static void WriteToXmlFile(List<Data> groups, string filename)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filename) ?? string.Empty);
        using StreamWriter writer = new StreamWriter(filename);
        new XmlSerializer(typeof(List<Data>)).Serialize(writer, groups);
    }
}