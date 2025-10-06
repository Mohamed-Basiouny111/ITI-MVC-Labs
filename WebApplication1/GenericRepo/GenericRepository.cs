using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.IGenericRepo;

namespace WebApplication1.GenericRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly TantaMVCContext _context;
        protected readonly DbSet<T> _table;

        public GenericRepository(TantaMVCContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public ICollection<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(int id)
        {
            return _table.Find(id);
        }

        public void Add(T entity)
        {
            _table.Add(entity);
            Save();
        }

        public void Update(T entity)
        {
            _table.Update(entity);
            Save();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _table.Remove(entity);
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

      
    }

}
