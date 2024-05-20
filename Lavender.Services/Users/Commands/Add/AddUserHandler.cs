using Lavender.Core.Shared;
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using Lavender.Core.Interfaces.Files;

namespace Lavender.Services.Users.Commands.Add
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IFileServices _fileServices;
        public AddUserHandler(IUnitOfWork unitOfWork, UserManager<User> userManager, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _fileServices = fileServices;
        }

        public async Task<Result> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
     
            try
            {
                var email = new MailAddress(request.Email);
            }
            catch(Exception)
            {
                return Result.Failure(new Error("400", "Invalid Email Address"));
            }
           

            var user = new User()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                ProfileImageUrl = await _fileServices.Upload(request.ProfileImage),
                BirthDay = request.BirthDay,
                NationalNumber = request.NationalNumber,
                PhoneNumber = request.PhoneNumber,  
                Address = request.Address,
            };

            IdentityResult IsAdd = await _unitOfWork.Users.AddWithRole(user, request.Role, request.Password);

            if (IsAdd.Succeeded)
            {
                await _unitOfWork.Save(cancellationToken);

                return Result.Success();
            }
            return Result.Failure(new Error("400", IsAdd.Errors.First().Description));


        }
    }
}
