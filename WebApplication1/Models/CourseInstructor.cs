using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("CourseInstructor")]
    public class CourseInstructor
    {
        public int InsId { get; set; }
        public int CrsId { get; set; }

        public virtual Instructor Instructor { get; set; }
        public virtual Course Course { get; set; }
    }
}
