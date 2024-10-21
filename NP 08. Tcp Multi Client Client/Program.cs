using System.Net;
using System.Net.Sockets;

var client = new TcpClient();
var ip = IPAddress.Parse("127.0.0.1");
var port = 27001;
var endPoint = new IPEndPoint(ip, port);

try
{
    client.Connect(endPoint);
    if (client.Connected)
    {
        var stream = client.GetStream();
        var bw = new BinaryWriter(stream);
        var br = new BinaryReader(stream);
        var writer = Task.Run(() =>
        {
            while (true)
            {
                var text = Console.ReadLine();
                bw.Write(text);
            }
        });

        var reader = Task.Run(() =>
        {
            while (true)
            {
                Console.WriteLine($"From server: {br.ReadString()}");
            }
        });
        Task.WaitAll(writer, reader);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}


