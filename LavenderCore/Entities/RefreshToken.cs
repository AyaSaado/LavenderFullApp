

namespace Lavender.Core.Entities
{
    public class RefreshToken
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public string Token { get; set; } = string.Empty;
        public string JwtId { get; set; } = string.Empty;
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        public DateTime ExpiryDate { get; set; }

    }
}
