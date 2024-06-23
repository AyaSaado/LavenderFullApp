

using MediatR;

namespace Lavender.Services.Users
{
    public class DeleteUserRequest : IRequest<bool>
    {
        public required List<Guid> Ids { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
