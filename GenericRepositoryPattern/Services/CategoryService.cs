using GenericRepositoryPattern.Context;
using GenericRepositoryPattern.Entities;
using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Repositories;

namespace GenericRepositoryPattern.Services
{
    public class CategoryService : GenericRepository<Category> , ICategoryService
    {
        private readonly MyContext _context;
        public CategoryService(MyContext context) : base(context)
        {
            _context = context;
        }


    }
}
