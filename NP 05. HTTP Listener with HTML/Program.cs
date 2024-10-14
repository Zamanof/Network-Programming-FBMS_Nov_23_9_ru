using System.Net;

var listener = new HttpListener();
listener.Prefixes.Add(@"http://localhost:27001/");

listener.Start();

while (true)
{
    var context = listener.GetContext();
    var response = context.Response;
    var request = context.Request;

    var userName = request.QueryString["login"];
    var userPassword = request.QueryString["password"];
    StreamWriter writer = new StreamWriter(response.OutputStream);

    if (userName == "admin" && userPassword == "admin")
    {
        writer.WriteLine(@$"<h1 style='color:blue'>Welcome {userName}</h1>");
    }
    else
    {
        writer.WriteLine(@$"<h1 style='color:red'>Incorrect login or password</h1>");
    }
    writer.Close();
}
