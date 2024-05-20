using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static Lavender.Services.Users.Queries.GetAll.GetAllUsersRequest;

namespace Lavender.Services.Users.Queries.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersRequest, List<UserResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public GetAllUsersHandler(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public Task<List<UserResponse>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
