using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.GenericRepo;
using WebApplication1.Models;

namespace WebApplication1.Repositry
{
    public class GenericStudentRepo : GenericRepository<Student>
    {
        public GenericStudentRepo(TantaMVCContext context) : base(context)
        {

        }

        public List<Student> GetStudent()
        {
            return _context.Students.Include(d => d.Department).Include(c => c.CourseStudents).ThenInclude(cs => cs.Course).ToList();


        }
    }

}
