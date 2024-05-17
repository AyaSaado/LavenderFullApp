using Azure.Core;
using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.DesignSections.Commands.Add
{
    public class AddDesignSectionsHandler : IRequestHandler<AddDesignSectionsRequest, Result<List<DesignSectionDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDesignSectionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<DesignSectionDto>>> Handle(AddDesignSectionsRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<DesigningSection>();
           
            foreach(var entity in request.DesignSectionsName)
            {
                entities.Add(new DesigningSection() { Name = entity });
            }

            try
            {
                await _unitOfWork.DesignSections.AddRangeAsync(entities);
                await _unitOfWork.Save(cancellationToken);
                
                return Mapping.Mapper.Map<List<DesignSectionDto>>(entities);

            }catch(Exception) 
            {
                return Result.Failure<List<DesignSectionDto>>(new Error("400" , "Adding Failed"));
            }

        }
    }
}
