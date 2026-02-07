namespace MovieManager.Services;

public interface IEmailSender
{
    void SendEmail(string senderName,string senderEmail, string toName, string toEmail,string subject, string textContext);
}