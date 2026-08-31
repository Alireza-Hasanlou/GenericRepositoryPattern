using GenericRepositoryPattern.Entities;

namespace GenericRepositoryPattern.Models
{
    public class HomePageViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
