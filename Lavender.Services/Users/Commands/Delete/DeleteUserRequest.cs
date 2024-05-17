

using MediatR;

namespace Lavender.Services.Users.Commands.Delete
{
    public class DeleteUserRequest : IRequest<bool>
    {
        public required List<Guid> Ids { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
