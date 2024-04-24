using FastEndpoints;
using FastEndpoints.Swagger;
using server.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddCors();
    services.AddFastEndpoints().SwaggerDocument();
    services.AddSwaggerGen();

    // services.AddEndpointsApiExplorer();

    // configure strongly typed settings object
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    // configure DI for application services
    services.AddSingleton<DatabaseContext>();
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
}

app.UseFastEndpoints().UseSwaggerGen();
app.UseDefaultExceptionHandler();

await app.RunAsync();
