using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("FriendshipConfirmations")]
    public class FriendshipConfirmations
    {
        [Key]
        public int ConfirmationId { get; set; }
        public string FriendshipSender { get; set; }
        public string FriendshipReceiver { get; set; }
        public string Confirmaiton { get; set; }
        public DateTime Date { get; set; }

    }
}
