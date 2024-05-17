using Lavender.Core.Shared;
using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace Lavender.Services.Users.Commands.Add
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, Result<UserDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public AddUserHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Result<UserDto>> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
     
            try
            {
                var email = new MailAddress(request.Email);
            }
            catch(Exception)
            {
                return Result.Failure<UserDto>(new Error("400", "Invalid Email Address"));
            }
           

            var user = new User()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                BirthDay = request.BirthDay,
                NationalNumber = request.NationalNumber,
                PhoneNumber = request.PhoneNumber,      
            };

            IdentityResult IsAdd = await _unitOfWork.Users.AddWithRole(user, request.Role, request.Password);

            if (IsAdd.Succeeded)
            {
                await _unitOfWork.Save(cancellationToken);

                var @new = (UserDto)HandlerServices.Map<User, UserDto>(user);
                var rs = await _userManager.GetRolesAsync(user);
                @new.Role = rs.First();
                return @new;
            }
            return Result.Failure<UserDto>(new Error("400", IsAdd.Errors.First().Description));


        }
    }
}
