using DependencyInjection.Models;
using DependencyInjection.Repositories.Interfaces;

namespace DependencyInjection.Repositories
{
    public class Repository : IRepository
    {
        //private Dictionary<string, Product> products;
        private IStorage _storage;
        public Repository(IStorage storage)
        {
            _storage = storage;

            //products = new Dictionary<string, Product>();
            new List<Product>
            {
                new Product {Name = "Шоколадка", Price = 250M},
                new Product {Name = "Хлеб", Price = 70M},
                new Product {Name = "Молоко", Price = 90M}
            }.ForEach(p => AddProduct(p));
        }
        public Product this[string name] => _storage[name];//products[name];

        public IEnumerable<Product> Products => _storage.Items;//products.Values;

        public void AddProduct(Product product)
            => _storage[product.Name] = product;//products[product.Name] = product;

        public void DeleteProduct(Product product)
            => _storage.RemoveKey(product.Name);//products.Remove(product.Name);

        /*private string guid = System.Guid.NewGuid().ToString();
        public override string ToString()
        {
            return guid;
        }*/
    }
}
