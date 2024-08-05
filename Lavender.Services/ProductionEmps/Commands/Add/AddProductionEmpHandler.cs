using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net.Mail;

namespace Lavender.Services.ProductionEmps
{
    public class AddProductionEmpHandler : IRequestHandler<AddProductionEmpRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;

        public AddProductionEmpHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
          
        }


        public async Task<Result> Handle(AddProductionEmpRequest request, CancellationToken cancellationToken)
        {

            if (!request.Email.IsNullOrEmpty())
            {
                try
                {
                    var email = new MailAddress(request.Email!);
                }
                catch (Exception)
                {
                    return Result.Failure(new Error("400", "Invalid Email Address"));
                }

            }
            if (!request.UserName.IsNullOrEmpty())
            {
                var UsersWithUserRequest = await _unitOfWork.Users.Find((u => u.UserName == request.UserName))
                                                              .ToListAsync(cancellationToken);

                if (UsersWithUserRequest.Count() > 0)
                {
                    return Result.Failure(new Error(
                       "400",
                       $"The UserName is already exist"));
                }

            }

            var productionemp = new ProductionEmp()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = !request.UserName.IsNullOrEmpty() ? request.UserName:(request.FullName + Guid.NewGuid().ToString()[..15]),
                HeadId = request.HeadId,
                LineTypeId = request.LineTypeId,
                BirthDay = request.BirthDay,
                Address = request.Address,
                ProfileImageUrl = await _fileServices.Upload(request.ProfileImage),
                NationalNumber = request.NationalNumber,
                PhoneNumber = request.PhoneNumber,
                Salary = request.Salary
            };

            IdentityResult IsAdd;
            if (!request.Password.IsNullOrEmpty())
            {
                 IsAdd = await _unitOfWork.Users.AddWithRole(productionemp, request.Role, request.Password!);
            }else
            {
                var roles = new List<string>() { request.Role };
                IsAdd = await _unitOfWork.Users.AddWithRole(productionemp, roles);
            }

            if (IsAdd.Succeeded)
            {
                await _unitOfWork.Save(cancellationToken);

                return Result.Success();

            }
            return Result.Failure(new Error("400", string.Join(Environment.NewLine, IsAdd.Errors.Select(e => e.Description))));

        }
    }
}
