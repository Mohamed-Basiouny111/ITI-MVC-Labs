using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("CourseStudent")]
    public class CourseStudent
    {
        public int StdId { get; set; }
        public int CrsId { get; set; }
        [MaxLength(100)]
        public int? Grade { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
