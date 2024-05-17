
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Lavender.Core.Interfaces.Files;
using static Lavender.Core.Helper.MappingProfile;
using Lavender.Core.Entities;
using System.Net.Mail;

namespace Lavender.Services.PatternMakers.Commands.Add
{
    public class AddPatternMakerHandler : IRequestHandler<AddPatternMakerRequest, Result<PatternMakerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;
        public AddPatternMakerHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
        }

        public async Task<Result<PatternMakerDto>> Handle(AddPatternMakerRequest request, CancellationToken cancellationToken)
        {
    
            try
            {
                var email = new MailAddress(request.Email);
            }
            catch (Exception)
            {
                return Result.Failure<PatternMakerDto>(new Error("400", "Invalid Email Address"));
            }

            var patternMaker = new PatternMaker()
            {
                FullName = request.FullName,
                Email = request.Email,
                UserName = request.UserName,
                BirthDay = request.BirthDay,
                ImageProfileUrl = await _fileServices.Upload(request.ImageProfile),
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
                    var d = await  _unitOfWork.DesignSections.GetOneAsync(d => d.Id == id);    
                   
                    sections.Add(Mapping.Mapper.Map<DesignSectionDto>(d));

                    makersections.Add(new MakerSection() { PatternMaker =  patternMaker, DesigningSection = d! });
                }

                await _unitOfWork.MakerSections.AddRangeAsync(makersections);
                await _unitOfWork.Save(cancellationToken);
                
                var @new = Mapping.Mapper.Map<PatternMakerDto>(patternMaker);
               
                @new.Role = request.Role;
                @new.DesignSectionDtos = sections;
              
                return @new;
            }
            return Result.Failure<PatternMakerDto>( new Error("400", string.Join(Environment.NewLine, IsAdd.Errors.Select(e => e.Description)))); 
          
        }
    }
}
