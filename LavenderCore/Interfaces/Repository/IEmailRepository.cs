using Lavender.Core.Helper;

namespace Lavender.Core.Interfaces.Repository
{
    public interface IEmailRepository
    {
        Task<bool> SendEmailAsync(Mailrequest mailrequest);
    }
}
