using Lavender.Core.Entities;
using Lavender.Core.Interfaces.Repository;
using MediatR;

namespace Lavender.Services.Chats
{
    public class AddChatHandler : IRequestHandler<AddChatRequest, bool>
    {
        private readonly ICRUDRepository<Chat> _chatRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AddChatHandler(ICRUDRepository<Chat> chatRepository, IUnitOfWork unitOfWork)
        {
            _chatRepository = chatRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddChatRequest request, CancellationToken cancellationToken)
        {
            var chat = new Chat()
            {
                ChatType = request.ChatType,
                DesignId = request.DesignId
            };
            
            try
            {
                await _chatRepository.AddAsync(chat);
                await _unitOfWork.Save(cancellationToken);


                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
