using MyPortfolio.Application.DTOs;

namespace MyPortfolio.Infrastructure.SmtpServices;

public interface IMailTemplateService
{
    //Task SendPasswordResetMailAsync(string resetLink);
    Task SendContactMessageNotificationAsync(ContactDto message);
}
