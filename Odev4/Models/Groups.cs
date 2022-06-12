using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("Groups")]
    public class Groups
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Member { get; set; }
        public List<Friends> Friends { get; set; }

    }
}
