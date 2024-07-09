using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using Lavender.Core.Interfaces.Files;

namespace Lavender.Services.Users
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IFileServices _fileServices;
        public UpdateUserHandler(IUnitOfWork unitOfWork, UserManager<User> userManager, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _fileServices = fileServices;
        }

        public async Task<Result> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Users.GetOneAsync(d => d.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                return Result.Failure(new Error(
                  "404",
                  $"The User with this Id was not found"));
            }

            entity.Update(request.FullName, request.PhoneNumber, request.NationalNumber
                          , request.BirthDay, request.Address);

            if (request.ProfileImage != null)
            {
                _fileServices.Delete(entity.ProfileImageUrl);

                entity.ProfileImageUrl = await _fileServices.Upload(request.ProfileImage);
            }

            if (!request.Role.IsNullOrEmpty())
            {
                var roles = await _userManager.GetRolesAsync(entity);

                await _userManager.RemoveFromRolesAsync(entity, roles);
               
                IdentityResult IsAdded = await _userManager.AddToRoleAsync(entity, request.Role!);

                if (!IsAdded.Succeeded)
                    return Result.Failure(new Error(
                    "400",
                    $"Wrong in Updating Role"));

            }

            if (!request.Password.IsNullOrEmpty())
            {
                IdentityResult TryUpdate = await _unitOfWork.Users.TryModifyPassword(entity, request.Password);
                if (TryUpdate.Succeeded)
                {
                    return await UpdateEntityinDB(entity, cancellationToken);
                }
                else
                    return Result.Failure(new Error("400", TryUpdate.Errors.First().Description));
            }
            else
                return await UpdateEntityinDB(entity, cancellationToken);
        }

        private async Task<Result> UpdateEntityinDB(User entity, CancellationToken cancellationToken)
        {
            await _userManager.UpdateAsync(entity);
            await _unitOfWork.Save(cancellationToken);
            return Result.Success();
        }

    }
}

