using System.ComponentModel.DataAnnotations;

namespace Rum8s.Models
{
    public class GroupR8
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

    }
}
