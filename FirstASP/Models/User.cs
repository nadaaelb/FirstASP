using System.ComponentModel.DataAnnotations;

namespace FirstASP.Models
{
    public class User
    {
        [Key]
        public int UserName { get; set; }
        public string? Password { get; set; }
    }
}
