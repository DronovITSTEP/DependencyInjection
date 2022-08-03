using DependencyInjection.Models;
using DependencyInjection.Repositories.Interfaces;

namespace DependencyInjection.Repositories
{
    public class ProductionRepository : IRepository
    {
        private Dictionary<string, Product> products;

        public ProductionRepository()
        {
            products = new Dictionary<string, Product>();
            new List<Product> { 
                new Product
                {
                    Name = "Пиво", Price = 45M
                },
                new Product
                {
                    Name = "Вино", Price = 459M
                },
                new Product
                {
                    Name = "Водка", Price = 660M
                }
            }.ForEach(p=>AddProduct(p));
        }
        public Product this[string name] => products[name];

        public IEnumerable<Product> Products => products.Values;

        public void AddProduct(Product product)
            => products[product.Name] = product;

        public void DeleteProduct(Product product)
            => products.Remove(product.Name);
    }
}
