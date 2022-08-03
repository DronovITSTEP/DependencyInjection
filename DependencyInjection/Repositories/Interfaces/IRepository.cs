using DependencyInjection.Models;

namespace DependencyInjection.Repositories.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }

        Product this[string name] { get; }
        void AddProduct(Product product);
        void DeleteProduct(Product product);
    }
}
