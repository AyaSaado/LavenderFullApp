using MediatR;
using Lavender.Core.Shared;
using Lavender.Core.EntityDto;

namespace Lavender.Services.Users.Commands.Update
{
    public class UpdateUserRequest : IRequest<Result<UserDto>>
    {
        public UserDto UserDto { get; set; } = null!; 
    }

        

}
