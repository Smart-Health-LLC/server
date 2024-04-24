namespace server.Configuration;

public static class SupportedLanguages
{
    public static readonly Language English = new()
    {
        Name = "English",
        Codes = ["en-EN"]
    };

    public static readonly Language Russian = new()
    {
        Name = "Russian",
        Codes = ["ru-RU"]
    };

    public static readonly Language French = new()
    {
        Name = "French",
        Codes = ["fr-FR"]
    };
}

public class Language
{
    public List<string> Codes = [];
    public string Name = "";
}
