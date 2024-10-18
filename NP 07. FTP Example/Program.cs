using System.Net;

getFTP();
//DownloadFTP();
//UploadFTP();
void getFTP()
{
    var request = WebRequest.Create("ftp://localhost:21") as FtpWebRequest;

    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

    var response = request.GetResponse() as FtpWebResponse;
    var stream = response.GetResponseStream();
    var sr = new StreamReader(stream);
    var data = sr.ReadToEnd();
    Console.WriteLine(data);
}

void DownloadFTP()
{
    var request = WebRequest.Create("ftp://localhost:21/Exam.txt") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.DownloadFile;

    var response = request.GetResponse() as FtpWebResponse;
    var stream = response.GetResponseStream();
    var fileStream = new FileStream("supperpuppermupper.txt", FileMode.Create);

    stream.CopyTo(fileStream);
    fileStream.Close();
    stream.Close();

}

void UploadFTP()
{
    var request = WebRequest.Create("ftp://localhost:21/Winter.txt") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.UploadFile;

    using var fs = new FileStream("supperpuppermupper.txt", FileMode.Open);
    using var stream = request.GetRequestStream();
    fs.CopyTo(stream);
}
