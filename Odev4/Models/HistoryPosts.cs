using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("HistoryPosts")]
    public class HistoryPosts
    {
        [Key]
        public int HistoryPostId { get; set; }
        public int PostId { get; set; }
        public Users User { get; set; }
        public string PostContent { get; set; }
        public string Additional { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string HistoryPostType { get; set; }
    }
}