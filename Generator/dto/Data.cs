namespace Generator.dto;


[Serializable]
public class Data
{
    public string value { get; set; }

    public Data() { }
    public Data(string name)
    {
        this.value = name;
    }
    
    public override string ToString()
    {
        return $"Value={value}";
    }
}