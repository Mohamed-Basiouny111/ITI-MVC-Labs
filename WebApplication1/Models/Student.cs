using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int SSN { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string? Age { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        [MaxLength(100)]
        public string? Image { get; set; }

    }
}
