using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System.Net;
using System.Net.Mail;
// SMTP, POP3, IMAP

//SMTP();
IMAP();

void SMTP()
{
    var client = new SmtpClient("smtp.gmail.com", 587);
    client.EnableSsl = true;
    client.Credentials = new NetworkCredential("fbms.1223@gmail.com", 
        "btbvudirnjpwentm");
    var message = new MailMessage()
    {
        Subject = "For test",
        Body = "Winter is coming (winter = exam)"
    };
    message.From = new MailAddress("fbms.1223@gmail.com", "Great MoguDa");
    message.To.Add(new MailAddress("elvinamustafayeva13@gmail.com"));
    message.To.Add(new MailAddress("saraftac@gmail.com"));
    message.To.Add(new MailAddress("eyvazovcamal2006@gmail.com"));
    message.To.Add(new MailAddress("elikosamed@gmail.com"));
    client.Send(message);
}

void IMAP()
{
    var imapClient = new ImapClient();
    imapClient.Connect("imap.gmail.com", 993, true);
    imapClient.Authenticate("fbms.1223@gmail.com",
        "btbvudirnjpwentm");

    var inbox = imapClient.GetFolder("Inbox");
    inbox.Open(FolderAccess.ReadWrite);

    var ids = inbox.Search(SearchQuery.All);

    foreach (var id in ids)
    {
        Console.WriteLine($"{id}. {inbox.GetMessage(id).TextBody}");
    }

    inbox.SetFlags(new UniqueId(42), MessageFlags.Deleted, true);
    inbox.Expunge();
    inbox.Close();
}
