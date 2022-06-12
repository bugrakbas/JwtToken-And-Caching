using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("Posts")]
    public class Posts
    {
        [Key]
        public int PostId { get; set; }
        public Users User { get; set; }
        public string PostContent { get; set; }
        public string Additional { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string PostType { get; set; }

    }
}
