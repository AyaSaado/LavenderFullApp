using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public Guid Sender_Id { get; set; }
        public string? Content { get; set; } 
        public string? URL { get; set; } 
        public DateTime SentTime { get; set; }
        public bool IsSeen { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; } = null!;  
        
    }
}
