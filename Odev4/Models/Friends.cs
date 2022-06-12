using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("Friends")]
    public class Friends
    {
        [Key]
        public int FriendshipId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Confirmation { get; set; }
        public Users User { get; set; }
    }
}
