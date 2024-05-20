using Lavender.Core.Entities;
using Lavender.Core.EntityDto;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings.Commands.Add.AddDesignSections
{
    public class AddDesignSectionsHandler : IRequestHandler<AddDesignSectionsRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddDesignSectionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddDesignSectionsRequest request, CancellationToken cancellationToken)
        {
            var entities = new List<DesigningSection>();

            foreach (var entity in request.DesignSectionsName)
            {
                entities.Add(new DesigningSection() { Name = entity });
            }

            try
            {
                await _unitOfWork.DesignSections.AddRangeAsync(entities);
                await _unitOfWork.Save(cancellationToken);

                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
