namespace api.Services.Interfaces;

public interface IMailService {
    public void SendMail(string email, string password);
}