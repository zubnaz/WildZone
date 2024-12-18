namespace Application.Interfaces;

public interface IMailService 
{
    Task SentMailAsync(string email, string subject, string message);
}
