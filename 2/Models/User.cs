using System.ComponentModel.DataAnnotations;

namespace _2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<UserTeam> UserTeam { get; set; }
    }
}
