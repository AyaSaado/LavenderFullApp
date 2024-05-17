
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Result<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public UpdateUserHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Result<UserDto>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Users.GetOneAsync(d => d.Id == request.UserDto.Id);

            if (entity is null)
            {
                return Result.Failure<UserDto>(new Error(
                  "404",
                  $"The User with Id {request.UserDto.Id} was not found"));
            }


            if (request.UserDto.Role.IsNullOrEmpty())
            {
                var roles = await _userManager.GetRolesAsync(entity);

                await _userManager.RemoveFromRolesAsync(entity, roles);
               
                IdentityResult IsAdded = await _userManager.AddToRoleAsync(entity, request.UserDto.Role!);

                if (!IsAdded.Succeeded)
                    return Result.Failure<UserDto>(new Error(
                    "400",
                    $"Wrong in Updating Role"));

            }


            Mapping.Mapper.Map(request.UserDto, entity);

            if (!request.UserDto.Password.IsNullOrEmpty())
            {
                IdentityResult TryUpdate = await _unitOfWork.Users.TryModifyPassword(entity, request.UserDto.Password);
                if (TryUpdate.Succeeded)
                {
                    return await UpdateEntityinDB(entity, cancellationToken);
                }
                else
                    return Result.Failure<UserDto>(new Error("400", TryUpdate.Errors.First().Description));
            }
            else
                return await UpdateEntityinDB(entity, cancellationToken);
        }

        private async Task<UserDto> UpdateEntityinDB(User entity, CancellationToken cancellationToken)
        {
            await _userManager.UpdateAsync(entity);
            await _unitOfWork.Save(cancellationToken);
            return (UserDto)HandlerServices.Map<User, UserDto>(entity);
        }

    }
}

