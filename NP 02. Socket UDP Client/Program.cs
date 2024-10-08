using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var connectEp = new IPEndPoint(IPAddress.Loopback, 27001);

var message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
Aliquam bibendum scelerisque metus sit amet blandit. 
Etiam vel facilisis nisi. Maecenas a mauris tristique, laoreet metus eu, tempor leo. 
Sed ut est ullamcorper neque ultrices pretium sit amet non lectus. 
Nam egestas dui nec faucibus ultrices. Duis vel dui tempor, molestie neque ut, dictum orci. 
Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. 
Curabitur egestas lorem viverra mi aliquam, vel fringilla mauris accumsan. 
Nullam at ornare lacus. Duis eget metus tristique, rhoncus risus ut, accumsan purus. 
Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; 
Nulla viverra dignissim dictum. Cras eget pulvinar nibh, eu maximus felis.
Curabitur sed condimentum arcu, euismod interdum diam. 
Pellentesque enim arcu, vestibulum vehicula neque nec, ultricies dapibus ligula. 
Aliquam id pellentesque leo, nec elementum quam. 
Nullam neque dolor, facilisis eu imperdiet nec, cursus at ipsum. 
Praesent consequat laoreet quam sit amet porta. Donec id commodo ipsum. 
Vivamus semper condimentum nulla, sed dapibus leo euismod scelerisque. 
Interdum et malesuada fames ac ante ipsum primis in faucibus. 
Maecenas cursus blandit diam, et blandit sem congue ut.
Donec eu rutrum nisl. 
Sed dignissim quam sit amet augue malesuada, eget pulvinar magna elementum. 
Morbi lacinia metus non dui tincidunt, eu blandit mauris consectetur. 
Donec eget erat et augue dignissim mollis. Aliquam id massa at erat feugiat auctor. 
Quisque mattis at leo ac porta.
Fusce a massa maximus, vestibulum turpis non, fermentum justo. 
Nunc sagittis aliquam sem, a finibus ex volutpat sit amet. 
Aliquam a metus finibus, tempus velit sit amet, placerat mauris. 
Sed tempus mattis sem, eget gravida libero vulputate quis. 
Proin et tortor sed felis mollis laoreet vel at urna. 
Sed enim tortor, porta sed tortor at, consectetur pellentesque tellus.
In sit amet arcu vel metus sodales dignissim vitae eget metus. 
Nunc pulvinar et nisi quis aliquam. 
Vestibulum id purus fringilla, hendrerit enim non, porttitor orci. 
In et auctor nulla, ut mollis nisl. 
Aliquam nec arcu placerat, porta quam et, fringilla lacus. Nam ac erat mauris. 
Nullam in neque eu ligula aliquet dapibus sit amet ut justo.
Etiam consequat sollicitudin venenatis. Nulla facilisi. 
Suspendisse eu sapien ipsum. 
Etiam sit amet odio lacinia est ullamcorper mattis non non enim. 
In id elit a augue molestie dictum. Proin hendrerit sed massa sit amet bibendum. 
Aenean ac risus ut lectus posuere pretium. 
Etiam eget ipsum non dolor egestas sagittis. 
Sed id sollicitudin sem. Ut ornare a ligula eget vestibulum. 
Aliquam erat volutpat. Vivamus sed nisl semper, semper elit nec, hendrerit dui. 
Morbi et eleifend ex.";

int count = 0;
while (true)
{
    var bytes = Encoding.Default.GetBytes(message[count++ % message.Length].ToString());
    Thread.Sleep(100);
    client.SendTo(bytes, connectEp);
}