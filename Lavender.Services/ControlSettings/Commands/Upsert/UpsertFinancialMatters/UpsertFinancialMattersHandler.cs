using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Lavender.Services.ControlSettings
{
    public class UpsertFinancialMattersHandler : IRequestHandler<UpsertFinancialMattersRequest, bool>
    {
        private readonly ICRUDRepository<FinancialMatters> _financialMattersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public UpsertFinancialMattersHandler(ICRUDRepository<FinancialMatters> financialMattersRepository, IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _financialMattersRepository = financialMattersRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<bool> Handle(UpsertFinancialMattersRequest request, CancellationToken cancellationToken)
        {
            var financialMatters = await _financialMattersRepository.GetOneAsync(f => f.Id == request.Id, cancellationToken);
       
            if(financialMatters == null)
            {
                financialMatters = new FinancialMatters();
            }

            var allEmpUsers = new List<User>();

            if (request.Executive_Salary != financialMatters.Executive_Salary)
            {
                allEmpUsers.AddRange(await UpdateEmpSalary(LavenderRoles.Executive, financialMatters.Executive_Salary));
            }

            if (financialMatters.Designer_Salary != request.Designer_Salary)
            {
                allEmpUsers.AddRange(await UpdateEmpSalary(LavenderRoles.Designer, financialMatters.Designer_Salary));
            }

            if (financialMatters.Tailor_Salary != request.Tailor_Salary)
            {
                allEmpUsers.AddRange(await UpdateEmpSalary(LavenderRoles.Tailor, financialMatters.Tailor_Salary));
            }


            financialMatters.Id = request.Id;
            financialMatters.Executive_Profit = request.Executive_Profit;
            financialMatters.Executive_Salary = request.Executive_Salary;
            financialMatters.Designer_Salary = request.Designer_Salary;
            financialMatters.Tailor_Salary = request.Tailor_Salary;
            financialMatters.Disscount_Range = request.Disscount_Range;


            try
            {
                _financialMattersRepository.Update(financialMatters);
                _unitOfWork.Users.UpdateRange(allEmpUsers);
                await _unitOfWork.Save(cancellationToken);

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private async Task<IEnumerable<User>> UpdateEmpSalary(LavenderRoles empRole, decimal Salary)
        {
            var Emps = await _userManager.GetUsersInRoleAsync(empRole.ToString());

           return Emps.Select(emp =>
            {
                emp.Salary = Salary;
                return emp;
            });

        }
    }
}
