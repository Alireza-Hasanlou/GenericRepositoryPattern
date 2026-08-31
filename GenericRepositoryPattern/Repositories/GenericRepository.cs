
using GenericRepositoryPattern.Context;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryPattern.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyContext _context;
        private DbSet<T> _dbSet = null;

        public GenericRepository(MyContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public bool Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void SaveChanges()
        {
            _dbSet.SingleAsync();
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
                SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
