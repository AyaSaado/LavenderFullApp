using MediatR;
using Microsoft.AspNetCore.Identity;
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Jwt;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;

namespace Lavender.Services.Users.Commands.Login
{
    public class LoginHandler : IRequestHandler<TokenRequest.Request, Result<TokenRequest.Respone>>
    {
        private readonly UserManager<User> _userManager;
        private HandlerServices services;
        public LoginHandler(UserManager<User> userManager, IJwtProvider jwtProvider, IUnitOfWork unitOfWork, ICRUDRepository<Core.Entities.RefreshToken> refreshTokenRepository)
        {
            _userManager = userManager;
            services = new HandlerServices(unitOfWork, jwtProvider , refreshTokenRepository);
      
        }

        public async Task<Result<TokenRequest.Respone>> Handle(TokenRequest.Request request, CancellationToken cancellationToken)
        {
            var UserExist = await _userManager.FindByNameAsync(request.UserName);


            if (UserExist == null)
            {
                return Result.Failure<TokenRequest.Respone>(new Error("404", "User Not Found"));
            }


            var IsPasswordMatch = await _userManager.CheckPasswordAsync(UserExist, request.Password);
            if (!IsPasswordMatch)
            {
                return Result.Failure<TokenRequest.Respone>(new Error("400", "Wrong Password"));
            }

            var roles = await _userManager.GetRolesAsync(UserExist);
            return await services.GenerateToken(UserExist, roles.ToList() ,cancellationToken);

           
        }
    }
}
