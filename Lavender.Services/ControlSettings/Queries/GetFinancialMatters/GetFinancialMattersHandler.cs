
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.ControlSettings
{
    public class GetFinancialMattersHandler : IRequestHandler<GetFinancialMattersRequest, FinancialMatters?>
    {
        private readonly ICRUDRepository<FinancialMatters> _financialMattersRepository;

        public GetFinancialMattersHandler(ICRUDRepository<FinancialMatters> financialMattersRepository)
        {
            _financialMattersRepository = financialMattersRepository;
        }

        public async Task<FinancialMatters?> Handle(GetFinancialMattersRequest request, CancellationToken cancellationToken)
        {
            return await _financialMattersRepository.GetAll().Include(f=>f.Disscount_Range).FirstOrDefaultAsync();
        }
    }
}
