namespace QA;

public class AccountData(string username, string password)
{
    public string Username {get; set;} = username;

    public string Password { get; set; } = password;
}