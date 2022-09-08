using GraphQLProjectCode.Interface;
using GraphQLProjectCode.Model;

namespace GraphQLProjectCode.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;
        public ProductService()
        {
            _products = new List<Product>() { new Product() { Id = 1, Description = "Product1", Name = "Product1", Price = 10 }, new Product() { Id = 2, Description = "Product2", Name = "Product2", Price = 20 } };
        }
        public Product Add(Product product)
        {
            _products.Add(product);
            return product;
        }

        public void Delete(int id)
        {
            _products.RemoveAt(id);
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.First(x => x.Id == id);
        }

        public Product Update(int id, Product product)
        {
            _products[id] = product;
            return product;
        }
    }
}
