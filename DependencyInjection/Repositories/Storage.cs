using DependencyInjection.Models;
using DependencyInjection.Repositories.Interfaces;

namespace DependencyInjection.Repositories
{
    public class Storage : IStorage
    {
        private Dictionary<string, Product> items = new Dictionary<string, Product>();
        public Product this[string key] 
        {
            get { return items[key]; }
            set { items[key] = value; } 
        }

        public IEnumerable<Product> Items => items.Values;

        public bool ContainKey(string key) => items.ContainsKey(key);

        public void RemoveKey(string key) => items.Remove(key);
    }
}
