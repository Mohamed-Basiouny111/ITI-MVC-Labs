using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.IRepo
{
    public interface IStudentRepo
    {
         ICollection<Student> getAll();
         Student getById(int id);
         Student getByIdWithDept(int id);
         void Add(Student student);
         void Edit(Student student);
         void Delete(int id);
         void Save();
    }
}
