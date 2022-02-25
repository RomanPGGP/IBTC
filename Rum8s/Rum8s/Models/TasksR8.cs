using System.ComponentModel.DataAnnotations;

namespace Rum8s.Models
{
    public class TasksR8
    {

        public int Id { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Display(Name = "Group")]
        public int GroupR8Id { get; set; }

        public GroupR8 Group { get; set; }


    }
}
