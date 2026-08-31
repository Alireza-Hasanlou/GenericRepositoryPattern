using GenericRepositoryPattern.Entities;
using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Repositories;

namespace GenericRepositoryPattern.Services
{
    public interface IProductService : IGenericRepository<Product>
    {

    }
}
