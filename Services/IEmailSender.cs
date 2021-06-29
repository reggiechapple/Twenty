using System.Threading.Tasks;

namespace Twenty.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
