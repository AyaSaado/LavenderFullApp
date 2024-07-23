using Lavender.Core.Entities;
using Lavender.Core.Helper;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Lavender.Services.Users
{
    public class ForgetPasswordHandler : IRequestHandler<ForgetPasswordRequest, string>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly UserManager<User> _userMangerRepository;
        private static readonly Random _random = new Random();
        public ForgetPasswordHandler(IEmailRepository emailRepository, UserManager<User> userMangerRepository)
        {
            _emailRepository = emailRepository;
            _userMangerRepository = userMangerRepository;
        }

        public async Task<string> Handle(ForgetPasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userMangerRepository.FindByEmailAsync(request.Email);
                if (user == null) return string.Empty;

                var code = _random.Next(1000, 9999).ToString("D4");

                var emailRequest = new Mailrequest()
                {
                    ToEmail = request.Email,
                    Subject = "Forget Password Confirm Code, Lavender App",
                    Body = code

                };
                await _emailRepository.SendEmailAsync(emailRequest);
                return code;
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }
    }
}
