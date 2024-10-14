using System.Net;

#region deprecated WebClient class
// WebClient - HTTP + FTP
//var webClient = new WebClient();
//Console.WriteLine(webClient.DownloadString(@"https://google.com"));
#endregion

var client = new HttpClient();

var requestMessage = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(@"https://google.az")
};

requestMessage.Headers.Add("Accept", "text/plain");
var response = await client.SendAsync(requestMessage);

//Console.WriteLine(response);
//Console.WriteLine(response.Headers);
//Console.WriteLine(response.StatusCode);
//Console.WriteLine(response.Content);
//Console.WriteLine(response.RequestMessage);

