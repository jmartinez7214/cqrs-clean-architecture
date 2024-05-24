using CleanArchitecture.Application.Models;

namespace CleanArchitecture.Application.Contracts.Infrastrucute
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
