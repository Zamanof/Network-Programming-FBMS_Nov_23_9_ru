using System.Net;
using System.Net.Sockets;
using System.Text;

var listener = new UdpClient(27001);
var ip = IPAddress.Parse("224.0.0.1");
listener.JoinMulticastGroup(ip);

var endPoint = new IPEndPoint(IPAddress.Any, 0);

while (true)
{
    var reciveBuffer = listener.Receive(ref endPoint);
    Console.WriteLine(Encoding.Default.GetString(reciveBuffer));
    Thread.Sleep(100);
    Console.Clear();
}
