using System.ComponentModel.DataAnnotations;

namespace _2.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<UserTeam> UserTeam { get; set; }
    }
}
