
using Lavender.Core.Interfaces.Jwt;
using Lavender.Services.Users.Commands.Login;
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using System.IdentityModel.Tokens.Jwt;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services
{
    public class HandlerServices
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<RefreshToken> _refreshTokenRepository;
        public HandlerServices(IUnitOfWork unitOfWork, IJwtProvider jwtProvider, ICRUDRepository<RefreshToken> refreshTokenRepository)
        {

            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
            _refreshTokenRepository = refreshTokenRepository;
        }
        public async Task<TokenRequest.Respone> GenerateToken (User user ,List<string> roles ,CancellationToken cancellationToken)
        {
  
            var Token = _jwtProvider.Generate(user,roles);
           
            Random r = new Random();

            var RefreshToken = new RefreshToken()
            {
                JwtId = Token.Id,
                Token = Guid.NewGuid().ToString() + r.NextDouble().ToString(),
                ExpiryDate = DateTime.UtcNow.AddMonths(1),
                UserId = user.Id,

            };

            await _refreshTokenRepository.AddAsync(RefreshToken);
            await _unitOfWork.Save(cancellationToken);


            return new TokenRequest.Respone()
            { Token = new JwtSecurityTokenHandler().WriteToken(Token), RefreshToken = RefreshToken.Token };
        }
        
        public static object Map<TSource, TDestination>(object entity)
        {
            if (entity is IEnumerable<TSource> source)
                entity = source.Select(element => Mapping.Mapper.Map<TDestination>(element)).ToList();
            else
                entity = Mapping.Mapper.Map<TDestination>(entity) ?? entity;
           return entity ;
        }
    }
}
