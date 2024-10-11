using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var ip = IPAddress.Parse("224.0.0.1");

client.JoinMulticastGroup(ip);
var endPoint = new IPEndPoint(ip, 27001);

List<string> messages = [
    @"/\________",
    @"_/\_______",
    @"__/\______",
    @"___/\_____",
    @"____/\____",
    @"_____/\___",
    @"______/\__",
    @"_______/\_",
    @"________/\",
    @"_________/",
    @"__________",
    @"\_________"
    ];
var i = 0;
var length = messages.Count;
while (true)
{
    var data = Encoding.Default.GetBytes(messages[i++ % length]);
    client.Send(data, endPoint);
    Thread.Sleep(100);
}
