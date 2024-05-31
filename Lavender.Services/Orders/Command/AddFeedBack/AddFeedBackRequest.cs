using Lavender.Core.EntityDto;
using Lavender.Core.Enum;
using MediatR;

namespace Lavender.Services.Orders.Command.AddFeedBack
{
    public class AddFeedBackRequest : IRequest<bool>
    {
        public int OrderId { get; set; }    
        public string? FeedBack { get; set; }
    }
}
