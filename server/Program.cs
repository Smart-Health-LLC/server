using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json.Serialization;
using server.Helpers;
using server.Repositories;
using server.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

// maybe migrate to SignalR, when the necessity push to this
app.UseWebSockets();

// add services to DI container
{
    var services = builder.Services;
    var env = builder.Environment;

    services.AddCors();
    services.AddSwaggerGen();
    services.AddEndpointsApiExplorer();
    services.AddControllers()
        .AddJsonOptions(jsonOptions =>
        {
            // serialize enums as strings in api responses (e.g. Role)
            jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

            // ignore omitted parameters on models to enable optional params (e.g. User update)
            jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // configure strongly typed settings object
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    // configure DI for application services
    services.AddSingleton<DataContext>();

    services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<ICaptureRepository, CaptureRepository>();
    services.AddScoped<ICaptureService, CaptureService>();
}


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

/***********************************
 ********* WEB SOCKETS *************
 ***********************************/

List<WebSocket?> connections = [];

async Task Broadcast(string message)
{
    var bytes = Encoding.UTF8.GetBytes(message);
    foreach (var socket in connections)
    {
        if (socket == null) continue;
        var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
        await socket.SendAsync(arraySegment,
            WebSocketMessageType.Text,
            true,
            CancellationToken.None);
    }
}

async Task ReceiveMessage(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
{
    var buffer = new byte[1024 * 4];
    while (socket.State == WebSocketState.Open)
    {
        var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        handleMessage(result, buffer);
    }
}

app.Map("/ws", async context =>
{
    if (context.WebSockets.IsWebSocketRequest)
    {
        using var ws = await context.WebSockets.AcceptWebSocketAsync();
        Console.Out.WriteLine("=== New connection");
        connections.Add(ws);
        await ReceiveMessage(ws, async (result, buffer) =>
        {
            if (result.MessageType == WebSocketMessageType.Text)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.Out.WriteLine(message);
            }
            else if (result.MessageType == WebSocketMessageType.Close || ws.State == WebSocketState.Aborted)
            {
                connections.Remove(ws);
                Console.Out.WriteLine("=== Closed connection");
            }
        });
    }
    else
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
    }
});

await app.RunAsync("http://localhost:6969");