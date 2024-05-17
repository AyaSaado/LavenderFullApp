using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ProductionEmps.Commands.Update
{
    public class UpdateProductionEmpHandler : IRequestHandler<UpdateProductionEmpRequest, Result<ProductionEmpDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<LineType> _lineTypeRepository;
        private readonly IFileServices _fileServices;

        public UpdateProductionEmpHandler(IFileServices fileServices, ICRUDRepository<LineType> lineTypeRepository, IUnitOfWork unitOfWork)
        {
            _fileServices = fileServices;
            _lineTypeRepository = lineTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<ProductionEmpDto>> Handle(UpdateProductionEmpRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.ProductionEmps.GetOneAsync(u => u.Id == request.Id);

            if (entity is null)
            {
                return Result.Failure<ProductionEmpDto>(new Error(
                  "404",
                  $"The User with Id {request.Id} was not found"));
            }

            var head = request.HeadId == Guid.Empty || request.HeadId == entity.Head?.Id ?
                                       entity.Head :
                                       await _unitOfWork.ProductionEmps.GetOneAsync(p => p.Id == request.HeadId);


            var linetype = request.LineTypeId == -1 || request.LineTypeId == entity.LineType.Id ?
                                     entity.LineType :
                                     await _lineTypeRepository.GetOneAsync(p => p.Id == request.LineTypeId);


            if (request.ImageProfile != null)
            {
                _fileServices.Delete(entity.ImageProfileUrl);

                entity.ImageProfileUrl = await _fileServices.Upload(request.ImageProfile);
            }

            entity.Update(request.FullName, request.PhoneNumber,
                          request.NationalNumber, request.BirthDay
                        , request.Salary, head, linetype!);


            if (!request.Password.IsNullOrEmpty())
            {
                IdentityResult TryUpdate = await _unitOfWork.Users.TryModifyPassword(entity, request.Password);
                if (TryUpdate.Succeeded)
                {
                    return await UpdateEntityinDB(entity, cancellationToken);
                }
                else
                    return Result.Failure<ProductionEmpDto>(new Error("400", TryUpdate.Errors.First().Description));
            }
            else
                return await UpdateEntityinDB(entity, cancellationToken);
        }

        private async Task<ProductionEmpDto> UpdateEntityinDB(ProductionEmp entity, CancellationToken cancellationToken)
        {
            _unitOfWork.ProductionEmps.Update(entity);
            await _unitOfWork.Save(cancellationToken);
            return Mapping.Mapper.Map<ProductionEmpDto>(entity);
        }
    }
}
