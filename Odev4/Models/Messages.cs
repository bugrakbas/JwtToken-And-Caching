using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("Messages")]
    public class Messages
    {
        [Key]
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public string Recipient { get; set; }
        public string Additional { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime UpdateTime { get; set; }
        public string MessageType { get; set; }

    }
}
