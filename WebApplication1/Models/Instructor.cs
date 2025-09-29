using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Instructor")]
    public class Instructor
    {
        [Key]
        public int SSN { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        [MaxLength(100)]
        public string? Salary { get; set; }
        [MaxLength(100)]
        public string? Age { get; set; }

        [ForeignKey(nameof(Department))]
        public int? DeptId { get; set; }
        public virtual Department Department { get; set; }

        public virtual List<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();

    }
}
