namespace WebApplication1.IGenericRepo
{
    public interface IGenericRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
