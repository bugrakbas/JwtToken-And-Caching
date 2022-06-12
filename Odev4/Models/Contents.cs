using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("Contents")]
    public class Contents
    {
        [Key]
        public int CommentId { get; set; }
        public Users User { get; set; }
        public string Post { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
