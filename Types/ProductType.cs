using GraphQL.Types;
using GraphQLProjectCode.Model;

namespace GraphQLProjectCode.Types
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.Price);
        }
    }
}
