using Lavender.Core.Entities;
using Lavender.Core.Enum;
using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Designs
{
    public class GetAllDesignsHandler : IRequestHandler<GetAllDesignsRequest, List<AllDesignsResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        public GetAllDesignsHandler(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<List<AllDesignsResponse>> Handle(GetAllDesignsRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.GetUsersInRoleAsync(LavenderRoles.Admin.ToString());
         
            var result = await _unitOfWork.Designs.Find(d => (user.Select(u=>u.Id).ToList().Contains(d.Order.ActorId)) &&
                                                        ((request.ItemId == 0) || (d.Order.ItemId == request.ItemId)) &&
                                                        ((request.ItemTypeId == 0) || (d.Order.ItemTypeId == request.ItemTypeId)))
                                             .Select(AllDesignsResponse.Selector())
                                             .ToListAsync(cancellationToken);

            foreach(var design in result)
            {
                design.OrdersOfDesignCount = await _unitOfWork.Orders.Find(o=>o.GalleryDesignId == design.Id)
                                                                     .CountAsync(cancellationToken);  
            }

            return result.OrderByDescending(d=>d.OrdersOfDesignCount)
                         .ToList(); 
        }
    }
}
