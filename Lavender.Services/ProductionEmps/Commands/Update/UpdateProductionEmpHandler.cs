using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Lavender.Services.ProductionEmps
{
    public class UpdateProductionEmpHandler : IRequestHandler<UpdateProductionEmpRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;

        public UpdateProductionEmpHandler(IFileServices fileServices, IUnitOfWork unitOfWork)
        {
            _fileServices = fileServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateProductionEmpRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ProductionEmps.GetOneAsync(u => u.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                return Result.Failure(new Error(
                  "404",
                  $"The User with Id {request.Id} was not found"));
            }


            if (request.ProfileImage != null)
            {
                _fileServices.Delete(entity.ProfileImageUrl);

                entity.ProfileImageUrl = await _fileServices.Upload(request.ProfileImage);
            }

            entity.Update(request.FullName, request.PhoneNumber,
                          request.NationalNumber, request.BirthDay
                        , request.Salary , request.Address);


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

        private async Task<Result> UpdateEntityinDB(ProductionEmp entity, CancellationToken cancellationToken)
        {
            _unitOfWork.ProductionEmps.Update(entity);
            await _unitOfWork.Save(cancellationToken);
            return Result.Success();
        }
    }
}
