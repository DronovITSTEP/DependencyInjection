using DependencyInjection.Models;

namespace DependencyInjection.Repositories.Interfaces
{
    public interface IStorage
    {
        IEnumerable<Product> Items { get; }
        Product this[string key] { get; set; }
        bool ContainKey (string key);
        void RemoveKey(string key);
    }
}
