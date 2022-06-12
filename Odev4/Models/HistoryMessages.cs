using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("HistoryMessages")]
    public class HistoryMessages
    {
        [Key]
        public int HidtoryMessageId { get; set; }
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public string Recipirnt { get; set; }
        public string Additional { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string MessageType { get; set; }

    }
}
