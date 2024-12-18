using Application.Interfaces;
using Domain.Models.Common;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace JwtRegisterAndLogin.Services;

public class MailService(IOptions<EmailSettings> emailSettings) : IMailService
{
    private readonly EmailSettings _emailSettings = emailSettings.Value;
    public Task SentMailAsync(string email, string subject, string message)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(_emailSettings.Email, _emailSettings.Password)
        };
       
        return client.SendMailAsync(
                new MailMessage(from: _emailSettings.Email, 
                                to: email, 
                                subject: subject, 
                                body: message));
    }
}
