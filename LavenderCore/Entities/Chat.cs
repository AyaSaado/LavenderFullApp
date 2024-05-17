

using Lavender.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Lavender.Core.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }
        public ChatType ChatType { get; set; }
        public Design Design { get; set; } = null!;
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
