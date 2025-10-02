using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Validators;

namespace WebApplication1.Models
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public int Num { get; set; }
        [Required(ErrorMessage = "Name Required")]
        [MaxLength(20, ErrorMessage = "Name Must be less than 20 Letters")]
        [Unique]
        public string Name { get; set; }
        [Required(ErrorMessage = "Topic Required")]
        [MaxLength(20, ErrorMessage = "Topic Must be less than 20 Letters")]
        public string? Topic { get; set; }
        [Required(ErrorMessage = "Degree Required")]
        public int Degree { get; set; }
        [Required(ErrorMessage = "MinDegree Required")]
        public int MinDegree { get; set; }

        public virtual List<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();
        public virtual List<CourseInstructor> CourseInstructors { get; set; } = new List<CourseInstructor>();

    }
}
