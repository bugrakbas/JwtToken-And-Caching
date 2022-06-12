using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("Users")]
    public class Users
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public virtual ICollection<Friends> Friends { get; set; }
        public virtual ICollection<Contents> Contents { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<HistoryPosts> HistoryPosts { get; set; }

    }
}
