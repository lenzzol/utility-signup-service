using System.Threading.Tasks;
using UtilitySignupService.Models;

namespace UtilitySignupService.Services
{
    public interface IEmailService
    {
        Task Send(NotifyType notifyType, Enrollment enrollment);
    }
}