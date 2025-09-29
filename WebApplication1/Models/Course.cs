using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int Num { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Topic { get; set; }

        public virtual List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
        public virtual List<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();

    }
}
