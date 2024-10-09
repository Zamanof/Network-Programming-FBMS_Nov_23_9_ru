using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();
var connectEP = new IPEndPoint(IPAddress.Loopback, 27001);

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
byte[] bytes = null;

while (true)
{
    bytes = Encoding.UTF8.GetBytes(messages[i++ % messages.Count]);
    client.Send(bytes, bytes.Length, connectEP);
    Thread.Sleep(100);
}
