namespace server.Configuration;

public class LanguageService : ILanguageService
{
    private readonly Language _default = SupportedLanguages.English;

    public LanguageService(IHttpContextAccessor httpContextAccessor)
    {
        var lang = httpContextAccessor.HttpContext?.Request.Headers.AcceptLanguage.ToString().Split(",")
            .FirstOrDefault();
        LanguageId = string.IsNullOrEmpty(lang) ? _default.Codes.First() : lang.Trim();
    }

    public string LanguageId { get; }
}
