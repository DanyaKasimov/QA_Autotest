namespace QA;


[Serializable]
public class Data
{
    public string value { get; set; }

    public Data() { }
    
    public Data(string name)
    {
        value = name;
    }
    
    public override string ToString()
    {
        return $"Value={value}";
    }
}