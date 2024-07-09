using MediatR;
using Microsoft.EntityFrameworkCore;
using Lavender.Core.Interfaces.Files;
using Lavender.Core.Interfaces.Repository;

namespace Lavender.Services.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserRequest, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileServices _fileServices;

        public DeleteUserHandler(IUnitOfWork unitOfWork, IFileServices fileServices)
        {
            _unitOfWork = unitOfWork;
            _fileServices = fileServices;
        }

        public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
           
            _fileServices.Delete(request.ImageUrls);

            var entities = await _unitOfWork.Users.Find(u => request.Ids.Contains(u.Id)).ToListAsync();

            try
            {
                _unitOfWork.Users.RemoveRange(entities);
                await _unitOfWork.Save(cancellationToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
