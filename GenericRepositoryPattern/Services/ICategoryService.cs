using GenericRepositoryPattern.Entities;
using GenericRepositoryPattern.Models;
using GenericRepositoryPattern.Repositories;

namespace GenericRepositoryPattern.Services
{
    public interface ICategoryService:IGenericRepository<Category>
    {
        //Other Service
    }
}
