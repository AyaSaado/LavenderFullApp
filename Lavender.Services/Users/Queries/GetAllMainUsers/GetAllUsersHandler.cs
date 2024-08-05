using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Lavender.Services.Users
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, List<AllUserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public GetAllUsersHandler(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<AllUserResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            return request.Role switch
            {
                "ProductionManager" => await _unitOfWork.ProductionEmps
                                                             .Find(p => (p.Head == null )
                                                                    && ((request.Name.IsNullOrEmpty()) 
                                                                    || (p.FullName.ToLower().StartsWith(request.Name.ToLower()))))
                                                             .Select(AllUserResponse.Selector())
                                                             .ToListAsync(cancellationToken),

                _ => await getUsersByRoleAsync(request.Role, request.Name , cancellationToken),
            };
        }

        private async Task<List<AllUserResponse>> getUsersByRoleAsync(string role,string name, CancellationToken cancellationToken)
        {
            IList<User> users;

            if (!role.IsNullOrEmpty())
            {
                users = await _userManager.GetUsersInRoleAsync(role);
            }
            else
            {
                users = await _userManager.Users.ToListAsync(cancellationToken);
            }

            var filteredUsers = users.Where(user => string.IsNullOrEmpty(name) || user.FullName.ToLower().StartsWith(name.ToLower()))
                              .Select(user => new AllUserResponse
                              {
                                  Id = user.Id,
                                  FullName = user.FullName,
                                  ProfileImageUrl = user.ProfileImageUrl,
                                  Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault(),
                              })
                              .ToList();

            return filteredUsers;
        }
       
    }
}
