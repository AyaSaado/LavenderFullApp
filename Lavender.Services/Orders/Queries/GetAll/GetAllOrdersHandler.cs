﻿using Lavender.Core.Interfaces.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Lavender.Services.Orders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, List<OrdersResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllOrdersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrdersResponse>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.Orders.Find(o => o.ActorId == request.ActorId
                                                        && (o.OrderState == request.OrderState))
                                                 .Select(OrdersResponse.Selector())
                                                 .ToListAsync(cancellationToken);

             return orders;
                                                       

        }
    }
}
