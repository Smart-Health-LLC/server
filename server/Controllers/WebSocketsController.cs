using System.Net;
using System.Net.WebSockets;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace server.Controllers;

[ApiController]
[Route("[controller]")]
public class WebSocketsController(ILogger<WebSocketsController> logger) : ControllerBase
{
    private readonly List<WebSocket?> _connections = [];

    [HttpGet("/ws")]
    public async Task Get()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            logger.Log(LogLevel.Information, "WebSocket connection established");

            await Console.Out.WriteLineAsync("New connection");

            _connections.Add(webSocket);

            await ReceiveMessage(webSocket, async (result, buffer) =>
            {
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    await Console.Out.WriteLineAsync(message);
                }
                else if (result.MessageType == WebSocketMessageType.Close || webSocket.State == WebSocketState.Aborted)
                {
                    _connections.Remove(webSocket);
                    await Console.Out.WriteLineAsync("Closed connection");
                }
            });
        }
        else
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }

    private async Task Broadcast(string message)
    {
        var bytes = Encoding.UTF8.GetBytes(message);
        foreach (var socket in _connections)
        {
            if (socket == null) continue;
            var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
            await socket.SendAsync(arraySegment,
                WebSocketMessageType.Text,
                true,
                CancellationToken.None);
        }
    }

    private async Task ReceiveMessage(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
    {
        var buffer = new byte[1024 * 4];
        while (socket.State == WebSocketState.Open)
        {
            var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            handleMessage(result, buffer);
        }
    }
}