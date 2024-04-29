using System.Text.Json;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;
using server.Configuration;
using server.Domain;
using server.Domain.User;
using server.Persistence;
using server.Persistence.User;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddLocalization()
        .Configure<RequestLocalizationOptions>(
            options =>
            {
                options.DefaultRequestCulture = SupportedCultures.DefaultRequestCulture;
                options.SetDefaultCulture(SupportedCultures.DefaultCulture.Name);
                options.SupportedCultures = SupportedCultures.Cultures;
                options.SupportedUICultures = SupportedCultures.Cultures;
            })
        .AddCors()
        .AddFastEndpoints()
        .AddAntiforgery()
        .AddAuthenticationJwtBearer(o => o.SigningKey = builder.Configuration["JwtSigningKey"])
        .AddAuthorization()
        .SwaggerDocument(o =>
        {
            o.DocumentSettings = s =>
            {
                s.DocumentName = "Initial Release";
                s.Title = "Pit API";
                s.Version = "v0";
                s.OperationProcessors.Add(new AcceptLanguageHeaderParameter());
            };
        })

        // better for union type returning endpoint handlers
        .Configure<JsonOptions>(o =>
            o.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase)

        // configure strongly typed settings object
        .Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"))

        // configure DI for application services
        .AddSingleton<DatabaseContext>()
        .AddScoped(typeof(IRepository<>), typeof(Repository<>))
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage()
        .UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        );

// This is used to allow the app to gather the requested language/culture from incoming requests
{
    var localizeOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
    app.UseRequestLocalization(localizeOptions!.Value);
}

app.UseAuthentication()
    .UseAuthorization()
    .UseAntiforgeryFE(); //must come before UseFastEndpoints()

const string routePrefix = "api";

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = routePrefix;
    // AllowAnonymous for all api/public/... endpoints
    c.Endpoints.Configurator = ep =>
    {
        if (ep.Routes != null && ep.Routes[0].StartsWith(routePrefix + "/public/")) ep.AllowAnonymous();
    };
    c.Versioning.Prefix = "v";
    // enable RFC7807 Compatible Problem Details in error responses
    c.Errors.UseProblemDetails();
});
app.UseSwaggerGen();
app.UseDefaultExceptionHandler();

await app.RunAsync();
