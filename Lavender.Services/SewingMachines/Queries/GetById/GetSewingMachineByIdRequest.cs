
using MediatR;

namespace Lavender.Services.SewingMachines
{
    public class GetSewingMachineByIdRequest : IRequest<SewingMachineResponse?>
    {
        public int Id { get; set; }
    }
}
