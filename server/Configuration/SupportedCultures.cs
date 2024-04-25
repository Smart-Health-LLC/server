using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace server.Configuration;

public static class SupportedCultures
{
    public static readonly List<CultureInfo> Cultures =
    [
        new CultureInfo("ru"),
        new CultureInfo("en-US")
    ];

    public static readonly CultureInfo DefaultCulture = new("en-US");
    public static readonly RequestCulture DefaultRequestCulture = new("en-US", "en-US");
}
