
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Lavender.Core.Interfaces.Files;
using static Lavender.Core.Helper.MappingProfile;
using Lavender.Core.Entities;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.PatternMakers
{
    public class AddPatternMakerHandler : IRequestHandler<AddPatternMakerRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;
        public AddPatternMakerHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
        }

        public async Task<Result> Handle(AddPatternMakerRequest request, CancellationToken cancellationToken)
        {
    
            try
            {
                var email = new MailAddress(request.Email);
            }
            catch (Exception)
            {
                return Result.Failure(new Error("400", "Invalid Email Address"));
            }

            var UsersWithUserRequest = await _unitOfWork.Users.Find((u => u.UserName == request.UserName))
                                                 .ToListAsync(cancellationToken);

            if (UsersWithUserRequest.Count() > 0)
            {
                return Result.Failure(new Error(
                   "400",
                   $"The UserName is already exist"));
            }

            var patternMaker = new PatternMaker()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                BirthDay = request.BirthDay,
                Address = request.Address,
                ProfileImageUrl = await _fileServices.Upload(request.ProfileImage),
                NationalNumber = request.NationalNumber,
                PhoneNumber = request.PhoneNumber,
                Salary = request.Salary
            };

            IdentityResult IsAdd = await _unitOfWork.Users.AddWithRole(patternMaker, request.Role , request.Password);
            

            if (IsAdd.Succeeded)
            {  
                var makersections = new List<MakerSection>();
                var sections = new List<DesignSectionDto>();
                
                foreach(var id in request.DesignSectionIds)
                {
                    var d = await  _unitOfWork.DesignSections.GetOneAsync(d => d.Id == id, cancellationToken);    
                   
                    sections.Add(Mapping.Mapper.Map<DesignSectionDto>(d));

                    makersections.Add(new MakerSection() { PatternMaker =  patternMaker, DesigningSection = d! });
                }

                await _unitOfWork.MakerSections.AddRangeAsync(makersections);
                await _unitOfWork.Save(cancellationToken);
              
                return Result.Success();
            }

            return Result.Failure( new Error("400", string.Join(Environment.NewLine, IsAdd.Errors.Select(e => e.Description)))); 
          
        }
    }
}
