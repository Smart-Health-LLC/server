using System.Text.Json;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.Options;
using server.Configuration;
using server.DataAccess;
using server.DataAccess.Interfaces;
using server.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddLocalization();
    services.Configure<RequestLocalizationOptions>(
        options =>
        {
            options.DefaultRequestCulture = SupportedCultures.DefaultRequestCulture;
            options.SetDefaultCulture(SupportedCultures.DefaultCulture.Name);
            options.SupportedCultures = SupportedCultures.Cultures;
            options.SupportedUICultures = SupportedCultures.Cultures;
        });

    services.AddCors();
    services.AddFastEndpoints();
    services.SwaggerDocument(o =>
    {
        o.DocumentSettings = s =>
        {
            s.DocumentName = "Initial Release";
            s.Title = "Pit API";
            s.Version = "v0";
            s.OperationProcessors.Add(new AcceptLanguageHeaderParameter());
        };
    });

    // better for union type returning endpoint handlers
    services.Configure<JsonOptions>(o =>
        o.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase);


    // configure strongly typed settings object
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));


    // configure DI for application services
    services.AddSingleton<DatabaseContext>();

    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped<IUserRepository, UserRepository>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

// app.UseWebSockets();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
}

// This is used to allow the app to gather the requested language/culture from incoming requests
var localizeOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(localizeOptions!.Value);

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
    c.Versioning.Prefix = "v";
    // enable RFC7807 Compatible Problem Details in error responses
    c.Errors.UseProblemDetails();
});
app.UseSwaggerGen();
app.UseDefaultExceptionHandler();

await app.RunAsync();
