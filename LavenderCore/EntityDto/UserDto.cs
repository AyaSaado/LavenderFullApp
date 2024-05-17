namespace Lavender.Core.EntityDto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NationalNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateOnly BirthDay { get; set; }
        public string Role { get; set; } = null!;
    }
}
