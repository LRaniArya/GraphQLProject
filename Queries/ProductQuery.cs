using GraphQL;
using GraphQL.Types;
using GraphQLProjectCode.Interface;
using GraphQLProjectCode.Types;

namespace GraphQLProjectCode.Queries
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProductService productService)
        {

            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAll(); });
            Field<ProductType>("product",
              arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
              resolve: context => { return productService.GetById(context.GetArgument<int>("id")); });
        
        
        }
    }
}
