using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static Lavender.Services.Users.Queries.GetById.GetUserByIdRequest;

namespace Lavender.Services.Users.Queries.GetById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, Result<UserResponse>>
    {
        public readonly IUnitOfWork _unitOfWork;

        public GetUserByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<UserResponse>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Users.Find(p => p.Id == request.Id)
                                                .Select(UserResponse.Selector())
                                                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
            {
                return Result.Failure<UserResponse>(new Error("404", "User Is Not Found"));
            }

            return entity;
        }
    }
}
