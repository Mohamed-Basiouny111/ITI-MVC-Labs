using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class TantaMVCContext : DbContext
    {
        public TantaMVCContext(DbContextOptions op) : base(op)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog=TantaMVC;Integrated Security=True;Trust Server Certificate=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // composite key M:M Course With Student
            modelBuilder.Entity<CourseStudent>()
                .HasKey(cs => new { cs.StdId, cs.CrsId });

            // relation with Student
            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Student)
                .WithMany(s => s.CourseStudents)
                .HasForeignKey(cs => cs.StdId);

            // relation with Course
            modelBuilder.Entity<CourseStudent>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseStudents)
                .HasForeignKey(cs => cs.CrsId);

            // composite key M:M Course With Instructor
            modelBuilder.Entity<CourseInstructor>()
                .HasKey(cs => new { cs.InsId, cs.CrsId });

            // relation with Instructor
            modelBuilder.Entity<CourseInstructor>()
                .HasOne(cs => cs.Instructor)
                .WithMany(s => s.CourseInstructors)
                .HasForeignKey(cs => cs.InsId);

            // relation with Course
            modelBuilder.Entity<CourseInstructor>()
                .HasOne(cs => cs.Course)
                .WithMany(c => c.CourseInstructors)
                .HasForeignKey(cs => cs.CrsId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
