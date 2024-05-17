

using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Jwt;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using Lavender.Services.Users.Commands.Login;
using System.IdentityModel.Tokens.Jwt;

namespace Lavender.Services.Users.Commands.RefreshToken
{
    
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenRequest, Result<TokenRequest.Respone>>
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<Core.Entities.RefreshToken> _refreshTokenRepository;
        private readonly HandlerServices services;
        private readonly UserManager<User> _userManager;
        private readonly TokenValidationParameters _tokenValidationParameters;
        public RefreshTokenHandler(IJwtProvider jwtProvider, IUnitOfWork unitOfWork, UserManager<User> userManager, IOptions<JwtBearerOptions> jwtBearerOptions, ICRUDRepository<Core.Entities.RefreshToken> refreshTokenRepository)
        {

            _unitOfWork = unitOfWork;
            services = new HandlerServices(unitOfWork, jwtProvider,refreshTokenRepository);
            _userManager = userManager;
            _tokenValidationParameters = jwtBearerOptions.Value.TokenValidationParameters;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<Result<TokenRequest.Respone>> Handle(RefreshTokenRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var JwtTokenHandler = new JwtSecurityTokenHandler();

                _tokenValidationParameters.ValidateLifetime = false; 
                var TokenInVarification = JwtTokenHandler.ValidateToken(request.Token, _tokenValidationParameters, out var validatedToken);

                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);

                    if (result == false)
                        return Result.Failure<TokenRequest.Respone>(new Error("400", "Invalid Token"));

                }else
                    return Result.Failure<TokenRequest.Respone>(new Error("400", "Invalid Request1"));

              
                var StoredToken = await _refreshTokenRepository.GetOneAsync(r => r.Token == request.RefreshToken);

                if (StoredToken == null)
                {
                    return Result.Failure<TokenRequest.Respone>(new Error("400", "Invalid RefreshToken"));
                }

                var jti = TokenInVarification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)!.Value;

                if (StoredToken.JwtId != jti)
                {
                    return Result.Failure<TokenRequest.Respone>(new Error("400", "Invalid Token"));
                }
                if (StoredToken.ExpiryDate < DateTime.UtcNow)
                {
                    return Result.Failure<TokenRequest.Respone>(new Error("400", "Expired RefreshToken"));
                }

                var user = await _unitOfWork.Users.GetOneAsync(u => u.Id == StoredToken.UserId);

                if(user is null)
                {
                    return Result.Failure<TokenRequest.Respone>(new Error("400", "Unadded User"));
                }
                _refreshTokenRepository.Remove(StoredToken);
                await _unitOfWork.Save(cancellationToken);

                var roles = await _userManager.GetRolesAsync(user);

                return await services.GenerateToken(user, roles.ToList(), cancellationToken);

            }
            catch (Exception)
            {
                return Result.Failure<TokenRequest.Respone>(new Error("400", "Invalid Request"));
            }


        }

   
    }
}
