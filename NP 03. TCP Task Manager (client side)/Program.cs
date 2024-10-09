using NP_03._TCP_Task_Manager__client_side_;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

var ip = IPAddress.Parse("10.2.22.13");
var port = 27001;

var client = new TcpClient();
client.Connect(ip, port);

var stream = client.GetStream();
var bw = new BinaryWriter(stream);
var br = new BinaryReader(stream);

Command command = null!;

string responce = null!;
string str = null!;

while (true)
{
    Console.WriteLine("Write command name or HELP");
    str = Console.ReadLine()!.ToUpper();
    if (str == "HELP")
    {
        Console.WriteLine();
        Console.WriteLine("Command list:");
        Console.WriteLine(Command.ProcessList);
        Console.WriteLine($"{Command.Run} <process_name>");
        Console.WriteLine($"{Command.Kill} <process_name>");
        Console.WriteLine("HELP");
        Console.ReadLine();
        Console.Clear();
    }

    var input = str.Split(' ');
    switch (input[0])
    {
        case Command.ProcessList:
            command = new Command { Text = input[0] };
            bw.Write(JsonSerializer.Serialize(command));
            responce = br.ReadString();
            var processList = JsonSerializer.Deserialize<string[]>(responce);
            foreach (var proc in processList!)
            {
                Console.WriteLine($"        {proc}");
            }

            break;
        case Command.Run:
            break;
        case Command.Kill:
            break;
        default:
            break;
    }
    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    Console.Clear();

}
