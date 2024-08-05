using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Lavender.Core.Helper.MappingProfile;

namespace Lavender.Services.ControlSettings
{
    public class UpdateLineTypeHandler : IRequestHandler<UpdateLineTypeRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<LineType> _lineTyperepository;
        private readonly UserManager<User> _userManager;
        public UpdateLineTypeHandler(IUnitOfWork unitOfWork, ICRUDRepository<LineType> lineTyperepository, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _lineTyperepository = lineTyperepository;
            _userManager = userManager;
        }

        public async Task<bool> Handle(UpdateLineTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = await _lineTyperepository.GetOneAsync(l => l.Id == request.LineTypeDto.Id, cancellationToken);
           
            if (entity == null)
            {
                return false;
            }
            var allProductionEmps = new List<ProductionEmp>();

            if (entity.ProductionManager_Salary != request.LineTypeDto.ProductionManager_Salary) 
            { 
                allProductionEmps.AddRange(await UpdateProductionEmp(LavenderRoles.ProductionManager, request.LineTypeDto.ProductionManager_Salary, entity.Id));
            }

            if (entity.Worker_Wage_EachHour != request.LineTypeDto.Worker_Wage_EachHour)
            {
                allProductionEmps.AddRange(await UpdateProductionEmp(LavenderRoles.Worker, request.LineTypeDto.Worker_Wage_EachHour, entity.Id));
            }

            Mapping.Mapper.Map(request.LineTypeDto, entity);

            try
            {
                  _lineTyperepository.Update(entity);
                  _unitOfWork.ProductionEmps.UpdateRange(allProductionEmps);
                  await _unitOfWork.Save(cancellationToken);
            
                  return true;
            }
            catch(Exception)
            {
                  return false;
            }
        }

        private async Task<IEnumerable<ProductionEmp>> UpdateProductionEmp(LavenderRoles productionRole, decimal productionEmp_Salary ,int lineTypeId)
        {
            var productionEmpsID = await _userManager.GetUsersInRoleAsync(productionRole.ToString());

            var productionEmps = await _unitOfWork.ProductionEmps.Find(u => productionEmpsID.Select(e => e.Id).Contains(u.Id) && u.LineTypeId == lineTypeId).ToListAsync();

            return  productionEmps.Select(emp =>
            {         
                emp.Salary = productionEmp_Salary;
                return emp;
            });

        }
    }
}
