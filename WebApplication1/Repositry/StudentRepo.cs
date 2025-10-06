using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.IRepo;
using WebApplication1.Models;

namespace WebApplication1.Repositry
{
    public class StudentRepo : IStudentRepo
    {
        TantaMVCContext db;
        public StudentRepo(TantaMVCContext _db)
        {
            db = _db;
        }
        public ICollection<Student> getAll()
        {
            return db.Students.Include(d => d.Department).Include(c => c.CourseStudents).ThenInclude(cs => cs.Course).ToList();
        }
        public Student getById(int id) 
        {
            return db.Students.Find(id);
        }
        public Student getByIdWithDept(int id)
        {
            return db.Students.Include(d => d.Department).FirstOrDefault(i => i.SSN == id);
        }
        public void Add(Student student)
        {
           // db.Students.Add(student);
            db.Add(student);
            Save();
            //db.SaveChanges();
        }
        public void Edit(Student student)
        {
            // db.Students.Add(student);
            db.Update(student);
            Save();
           // db.SaveChanges();
        }
        public void Delete(int id)
        {
            var std = getById(id);
            db.Remove(std);
            Save();
            //db.SaveChanges();
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
