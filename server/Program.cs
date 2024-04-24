using FastEndpoints;
using FastEndpoints.Swagger;
using server.Configuration;
using server.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

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

    services.AddLocalization();

    // configure strongly typed settings object
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    // configure DI for application services
    services.AddSingleton<DatabaseContext>();
    builder.Services.AddScoped<ILanguageService, LanguageService>();
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

app.UseFastEndpoints(c =>
{
    c.Endpoints.RoutePrefix = "api";
    c.Versioning.Prefix = "v";
});
app.UseSwaggerGen();
app.UseDefaultExceptionHandler();

await app.RunAsync();
