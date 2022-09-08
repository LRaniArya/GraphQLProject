using GraphQLProjectCode.Model;

namespace GraphQLProjectCode.Interface
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Add(Product product);
        Product Update(int id, Product product);
        void Delete(int id);

    }
}
