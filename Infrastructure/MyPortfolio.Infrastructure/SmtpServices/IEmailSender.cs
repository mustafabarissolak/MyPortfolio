namespace MyPortfolio.Infrastructure.SmtpServices;

public interface IEmailSender
{
    Task SendEmailAsync(string to, string subject, string body);
}




