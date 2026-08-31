using GenericRepositoryPattern.Context;
using GenericRepositoryPattern.Entities;
using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Repositories;

namespace GenericRepositoryPattern.Services
{
    public class ProductService : GenericRepository<Product>, IProductService
    {
        private readonly MyContext _context;
        public ProductService(MyContext context) : base(context)
        {
            _context = context;
        }


    }
}
