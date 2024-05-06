using MailKit.Net.Smtp;
using MimeKit;
public class MailService: IMailService 
{
    IConfiguration _configuration;
    ILogger<MailService> _logger;
    public MailService(IConfiguration configuration, ILogger<MailService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }
    public void SendMail(string email, string password) 
    {
        int numberOfCharactersForEmailEnding = 12;
        string username = email.Substring(0, email.Length - numberOfCharactersForEmailEnding);
        var message = new MimeMessage();
        message.From.Add(new MailboxAddress(name: "UC Reviews", address: "uchousingreviews@gmail.com"));
        message.To.Add(new MailboxAddress(name: username, address: email));
        message.Subject = "Temporary Password for UC Reviews";
        message.Body = new TextPart("plain") 
        {
            Text = $"Your temporary UCReviews password is: {password}"
        };

        _logger.LogError(_configuration["UCReviewsPassword"]);
        using (var client = new SmtpClient())
        {
            client.Connect(host: "smtp.gmail.com", port: 587, useSsl: false);
            client.Authenticate(userName: "uchousingreviews@gmail.com", password: _configuration["UCReviewsPassword"]);
            client.Send(message);
            client.Disconnect(quit: true);
        }
    }
}