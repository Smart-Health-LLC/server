using System.Text.Json.Serialization;
using server.Helpers;
using server.Repositories;
using server.DataAccess;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddCors();
    services.AddSwaggerGen();
    services.AddControllers()
        .AddJsonOptions(jsonOptions =>
        {
            // serialize enums as strings in api responses (e.g. Role)
            jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            // ignore omitted parameters on models to enable optional params (e.g. User update)
            jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
    services.AddEndpointsApiExplorer();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // configure strongly typed settings object
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    // configure DI for application services
    services.AddSingleton<DatabaseContext>();

    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ICaptureService, CaptureService>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

// maybe migrate to SignalR, when the necessity push to this
app.UseWebSockets();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();
}

app.MapControllers();

await app.RunAsync();
