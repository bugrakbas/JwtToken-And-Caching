using System.ComponentModel.DataAnnotations.Schema;

namespace Odev4.Models
{
    [Table("LoginModel")]
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
