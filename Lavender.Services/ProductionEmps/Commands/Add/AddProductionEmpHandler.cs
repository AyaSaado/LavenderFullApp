using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace Lavender.Services.ProductionEmps
{
    public class AddProductionEmpHandler : IRequestHandler<AddProductionEmpRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<LineType> _lineTypeRepository;
        private readonly IFileServices _fileServices;

        public AddProductionEmpHandler(IUnitOfWork unitOfWork, IFileServices fileServices, ICRUDRepository<LineType> lineTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
            _lineTypeRepository = lineTypeRepository;
        }


        public async Task<Result> Handle(AddProductionEmpRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var email = new MailAddress(request.Email);
            }
            catch (Exception)
            {
                return Result.Failure(new Error("400", "Invalid Email Address"));
            }
           
         

          

            var productionemp = new ProductionEmp()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                HeadId = request.HeadId,
                LineTypeId = request.LineTypeId,
                BirthDay = request.BirthDay,
                Address = request.Address,
                ProfileImageUrl = await _fileServices.Upload(request.ProfileImage),
                NationalNumber = request.NationalNumber,
                PhoneNumber = request.PhoneNumber,
                Salary = request.Salary
            };

            IdentityResult IsAdd = await _unitOfWork.Users.AddWithRole(productionemp, request.Role, request.Password);

            if (IsAdd.Succeeded)
            {
                await _unitOfWork.Save(cancellationToken);

                return Result.Success();

            }
            return Result.Failure(new Error("400", string.Join(Environment.NewLine, IsAdd.Errors.Select(e => e.Description))));

        }
    }
}
