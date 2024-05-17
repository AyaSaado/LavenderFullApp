using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;
using static Lavender.Core.Helper.MappingProfile;
using Lavender.Core.Interfaces.Files;

namespace Lavender.Services.PatternMakers.Commands.Update
{
    public class UpdatePatternMakerHandler : IRequestHandler<UpdatePatternMakerRequest, Result<PatternMakerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;
        public UpdatePatternMakerHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
        }

        public async Task<Result<PatternMakerDto>> Handle(UpdatePatternMakerRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.PatternMakers.GetOneAsync(u=> u.Id == request.Id);
            
            if (entity is null)
            {
                  return Result.Failure<PatternMakerDto>(new Error(
                    "404",
                    $"The User with Id {request.Id} was not found"));
            }


            if (request.ImageProfile != null)
            {
                _fileServices.Delete(entity.ImageProfileUrl);
            
                entity.ImageProfileUrl = await _fileServices.Upload(request.ImageProfile);
            }

            entity.Update(request.FullName , request.PhoneNumber,
                          request.NationalNumber, request.BirthDay, request.Salary);


            if (!request.Password.IsNullOrEmpty())
            {
                IdentityResult TryUpdate = await _unitOfWork.Users.TryModifyPassword(entity, request.Password);
                if (TryUpdate.Succeeded)
                {
                    return await UpdateEntityinDB(entity, cancellationToken); 
                }else
                    return Result.Failure<PatternMakerDto>(new Error("400", TryUpdate.Errors.First().Description));
            }
            else
                return await UpdateEntityinDB(entity, cancellationToken);
        }

        private async Task<PatternMakerDto> UpdateEntityinDB(PatternMaker entity ,CancellationToken cancellationToken)
        {
            _unitOfWork.PatternMakers.Update(entity);
            await _unitOfWork.Save(cancellationToken);
            return Mapping.Mapper.Map<PatternMakerDto>(entity);
        }


        //if (request.Role.IsNullOrEmpty())
        //{
        //    var roles = await _userManager.GetRolesAsync(entity);

        //    await _userManager.RemoveFromRolesAsync(entity, roles);

        //    IdentityResult IsAdded = await _userManager.AddToRoleAsync(entity, request.Role!);

        //    if (!IsAdded.Succeeded)
        //        return Result.Failure<PatternMakerDto>(new Error(
        //        "400",
        //        $"Wrong in Updating Role"));

        //}
    }
}

