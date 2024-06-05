using System;
using WebSocketSharp;
using WebSocketSharp.Server;

public class VideoBehavior : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        Sessions.Broadcast(e.RawData);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var wssv = new WebSocketServer("ws://localhost:8080");
        wssv.AddWebSocketService<VideoBehavior>("/video");
        wssv.Start();
        Console.WriteLine("WebSocket server started at ws://localhost:8080");
        Console.ReadKey();
        wssv.Stop();
    }
}
