using Lavender.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Lavender.Core.Interfaces.Repository
{
    public interface IUserRepository : ICRUDRepository<User>
    {
       
        Task<IEnumerable<User>> GetAllByRole(string role);
        Task<IdentityResult> AddWithRole(User user, string role, string password);
        Task<IdentityResult> AddWithRole(User user, ICollection<string> roles);
       // Task<bool> IsEmailExist<User>(string email, Guid? id = null);
        Task<IdentityResult> TryModifyPassword(User user, string? newPassword);

    }
}
