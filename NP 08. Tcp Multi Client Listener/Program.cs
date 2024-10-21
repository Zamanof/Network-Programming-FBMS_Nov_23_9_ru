using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections.Concurrent;

TcpListener listener = null;
BinaryReader br = null;
BinaryWriter bw = null;
List<TcpClient> clients = [];

var ip = IPAddress.Parse("10.2.22.1");
var port = 27001;
var endPoint = new IPEndPoint(ip, port);
listener = new TcpListener(endPoint);

listener.Start(10);


while (true)
{
    var client = await listener.AcceptTcpClientAsync();
    clients.Add(client);
    Console.WriteLine($"{client.Client.RemoteEndPoint} connected...");

    var reader = Task.Run(() => {
        try
        {
            while (true)
            {
                var stream = client.GetStream();
                br = new BinaryReader(stream);
                var message = br.ReadString();
                Console.WriteLine($"Client {client.Client.RemoteEndPoint}: {message}");
            }
        }
        catch (Exception)
        {
            Console.WriteLine($"{client.Client.RemoteEndPoint} disconnected.");
            clients.Remove(client);
        }
    });

    var writer = Task.Run(() => {
        while (true)
        {
            var message = Console.ReadLine();
            foreach (var client in clients)
            {
                var stream = client.GetStream();
                bw = new BinaryWriter(stream);
                bw.Write(message);
            }
        }
    });
}
