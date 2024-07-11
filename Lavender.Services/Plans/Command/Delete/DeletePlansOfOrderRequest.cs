
using MediatR;

namespace Lavender.Services.Plans
{
    public class DeletePlansOfOrderRequest : IRequest<bool>
    {
        public List<int> Ids { get; set; } = new List<int>();           
    }
}
