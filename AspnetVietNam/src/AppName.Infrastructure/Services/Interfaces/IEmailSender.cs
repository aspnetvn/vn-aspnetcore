using System.Threading.Tasks;

namespace AppName.Infrastructure.Services.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string addressEmail, string subject, string message);
    }
}
