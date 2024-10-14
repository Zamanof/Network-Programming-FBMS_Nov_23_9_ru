using System.Net;

var listener = new HttpListener();
listener.Prefixes.Add(@"http://localhost:27001/");

listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    //Console.WriteLine(request);
    var rawUrl = request.RawUrl;
    //Console.WriteLine(rawUrl);
    // /?login=Nadir&password=qwerty
    //var queryString = rawUrl.Split('?')[1];
    //var strings = queryString.Split('&');
    //for ( var i = 0; i < strings.Length; i++)
    //{
    //    var data = strings[i].Split('=');
    //    Console.WriteLine($"key={data[0]}, value ={data[1]}");
    //}

    //foreach(string key in request.QueryString.Keys)
    //{
    //    Console.WriteLine($"key={key} - value={request.QueryString[key]}");
    //}

    //response.AddHeader("Content-Type", "text/plain");

    StreamWriter writer = new StreamWriter(response.OutputStream);
    //writer.Write($"Salam {request.QueryString["name"]}");

    writer.WriteLine(@$"<h1 style='color:Red'>Salam {request.QueryString["name"]}</h1>");

    writer.WriteLine(@$"<a href='https://google.com/?q={request.QueryString["name"]}'>Search</a>");

    writer.WriteLine($@"<img src='https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQliJsyFLWC1G6BBX5W3_fRhGtlfNuS-UtdRg&s' alt='some image'>");
    writer.Close();
   
}
