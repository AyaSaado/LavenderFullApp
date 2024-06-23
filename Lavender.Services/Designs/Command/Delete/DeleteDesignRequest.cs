
using MediatR;

namespace Lavender.Services.Designs
{
    public class DeleteDesignRequest : IRequest<bool>
    {
        public int DesignId { get; set; }
    }
}
