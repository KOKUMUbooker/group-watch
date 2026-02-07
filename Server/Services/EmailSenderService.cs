using MailKit.Net.Smtp;
using MimeKit;


namespace MovieManager.Services;

public class EmailSender : IEmailSender
{
    private readonly string?  SmtpServer;
    private readonly int SmtpPort;
    private readonly string?  SmtpUsername;
    private readonly string?  SmtpPassword;

    public EmailSender(IConfiguration configuration)
    {
        SmtpServer = configuration.GetValue<string>("SmtpSettings:SmtpServer","");
        SmtpPort = configuration.GetValue<int>("SmtpSettings:SmtpPort",0);
        SmtpUsername = configuration.GetValue<string>("SmtpSettings:SmtpUsername","");
        SmtpPassword = configuration.GetValue<string>("SmtpSettings:SmtpPassword","");
    }

    public void SendEmail(string senderName,string senderEmail, string toName, string toEmail,string subject, string textContext)
    {
          var message = new MimeMessage();
            message.From.Add (new MailboxAddress(senderName, senderEmail));
            message.To.Add (new MailboxAddress(toName,toEmail));
            message.Subject = subject;

            message.Body = new TextPart ("plain") {
                Text =  textContext
            };

            using (var client = new SmtpClient ()) {
                client.Connect (SmtpServer, SmtpPort, false);

                client.Authenticate (SmtpUsername,SmtpPassword);

                try
                {
                    client.Send (message);

                    client.Disconnect (true);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
    }
}
 