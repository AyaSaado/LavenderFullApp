
using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using Lavender.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Constants
{
    public class HomeReportHandler : IRequestHandler<HomeReportRequest, HomeResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public HomeReportHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<HomeResponse> Handle(HomeReportRequest request, CancellationToken cancellationToken)
        {
            var result = new HomeResponse();

            // get counts ....

             result.CompletedOrders = await _unitOfWork.Orders.Find(o => o.OrderState == OrderState.outlet)
                                                              .CountAsync(cancellationToken); 
             
             result.UnderWayOrders = await _unitOfWork.Orders.Find(o=> o.OrderState == OrderState.underway)
                                                            .CountAsync(cancellationToken);


            result.OurClients = await GetUserCountOfRole(LavenderRoles.Customer.ToString());

            result.ProductionManagers = await  GetUserCountOfRole(LavenderRoles.ProductionManager.ToString());
           
            result.ProductionWorkers = await GetUserCountOfRole(LavenderRoles.Worker.ToString());

            result.Designers = await GetUserCountOfRole(LavenderRoles.Designer.ToString());

            result.Tailors = await GetUserCountOfRole(LavenderRoles.Tailor.ToString());

            result.StoreManagers = await GetUserCountOfRole(LavenderRoles.PurchaseManager.ToString());

            // get orders counts ...
            DateOnly firstDayOfMonth = new DateOnly(request.Date.Year, request.Date.Month, 1);
            DateOnly lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1); // Get the last day of the month


            var ordersDate = await _unitOfWork.Orders
                .Find(o => o.OrderDate >= firstDayOfMonth && o.OrderDate <= lastDayOfMonth)
                .Select(o => o.OrderDate)
                .ToListAsync(cancellationToken);
          
            var datesInMonth =
             Enumerable.Range(1, DateTime.DaysInMonth(request.Date.Year, request.Date.Month))
                       .Select(day => new DateOnly(request.Date.Year, request.Date.Month, day));

            var dailyCount = datesInMonth.ToDictionary(date => date, _ => 0);

            foreach(var date in ordersDate) 
            {
                if (dailyCount.ContainsKey(date))
                {
                    dailyCount[date] += 1;
                }
            }
            result.DailyOrdersCounts = dailyCount.Values.ToList();

            return result;

        }

        private async Task<int> GetUserCountOfRole(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);

            return users.Count;

        }
    }
}
