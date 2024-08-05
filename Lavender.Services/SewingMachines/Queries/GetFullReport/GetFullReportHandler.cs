
using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.SewingMachines
{
    public class GetFullReportHandler : IRequestHandler<GetFullReportRequest, ProductionReport>
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly ICRUDRepository<SewingMachine> _sewingMachineRepository;
        private readonly ICRUDRepository<Step> _stepRepository;
        public GetFullReportHandler(IUnitOfWork unitOfWork, ICRUDRepository<SewingMachine> sewingMachineRepository, ICRUDRepository<Step> sstepRepository)
        {
            _unitOfWork = unitOfWork;
            _sewingMachineRepository = sewingMachineRepository;
            _stepRepository = sstepRepository;
        }

        public async Task<ProductionReport> Handle(GetFullReportRequest request, CancellationToken cancellationToken)
        {  
            var result = new ProductionReport();

            int duration = (request.ToDate.ToDateTime(new TimeOnly()) - request.FromDate.ToDateTime(new TimeOnly())).Days;

            var machines = await _sewingMachineRepository.Find(s => (s.Active) 
                                                           &&((s.ProductionEmp.HeadId == request.ProductionId) ||
                                                           (s.ProductionEmpId == request.ProductionId)))
                                                         .Include(s=>s.ModelName)
                                                         .Include(s=>s.DailyProductions)
                                                         .ToListAsync(cancellationToken);

            result.TotalMachines = machines.Count;

            result.ProductivityOfMachines = machines.Sum(m => m.ModelName!.Productivity) * duration;


            result.TotalEmps = await _unitOfWork.ProductionEmps.Find(s => s.HeadId == request.ProductionId)
                                                        .CountAsync(cancellationToken);

            var orders = await _unitOfWork.Orders.Find(o => o.ProductionLineId == request.ProductionId)
                                               .ToListAsync(cancellationToken);

            var steps = await _stepRepository.GetAll().ToListAsync(cancellationToken);


            foreach(var step in steps.Where(s=>s.Id != steps.Last().Id))
            {
                var productivity = new ProductivityOfStep
                {
                    StepId = step.Id,
                    ItemQuantity = orders
                                 .SelectMany(o => o.ItemSizes)
                                 .SelectMany(i => i.Plans)
                                 .Where(p => p.StepId == step.Id)
                                 .Sum(p => p.Amount),

                    OrdersCount = orders.Count(o => o.ItemSizes.Any(i => i.Plans.Any(p =>( p.StepId == step.Id) && (p.Amount != 0))))
                };

                result.ProductivityOfStep.Add(productivity);
            }

            // Filter DailyProduction records within the specified date range
            var dailyProductions = machines.SelectMany(m => m.DailyProductions)
                                           .Where(dp => dp.Day >= request.FromDate && dp.Day <= request.ToDate)
                                           .ToList();

            if (dailyProductions.Any())
            {
                result.ProductivityOfWorker = dailyProductions.Sum(dp => dp.WorkQuantity);
            }

            return result;
        }
    }
}
