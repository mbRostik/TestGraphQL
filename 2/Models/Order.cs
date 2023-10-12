using System.ComponentModel.DataAnnotations;

namespace _2.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
