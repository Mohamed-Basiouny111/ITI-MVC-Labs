using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Manger { get; set; }

        public virtual List<Student> Students { get; set; } = new List<Student>();

        public virtual List<Instructor> Instructors { get; set; } = new List<Instructor>();

    }
}
