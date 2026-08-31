namespace GenericRepositoryPattern.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T GetById(int id);
        void SaveChanges();
        IEnumerable<T> GetAll();
    }
}
