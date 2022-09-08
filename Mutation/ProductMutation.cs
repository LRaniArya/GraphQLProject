using GraphQL;
using GraphQL.Types;
using GraphQLProjectCode.Interface;
using GraphQLProjectCode.Model;
using GraphQLProjectCode.Types;

namespace GraphQLProjectCode.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProductService productService)
        {
            Field<ProductType>("createProduct", arguments: new QueryArguments() { new QueryArgument<ProductInputType>() { Name = "product" } },
                resolve: context =>
                {
                    return productService.Add(context.GetArgument<Product>("product"));
                }
                );
            Field<ProductType>("updateProduct", arguments: new QueryArguments() { new QueryArgument<IntGraphType>() { Name = "id" }, new QueryArgument<ProductInputType>() { Name = "product" } },
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var productObj = context.GetArgument<Product>("product");
                    return productService.Update(id, productObj);
                }
                );
            Field<StringGraphType>("deleteProduct", arguments: new QueryArguments() { new QueryArgument<IntGraphType>() { Name = "id" } },
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    productService.Delete(id);
                    return $"The Product against {id} has been deleted.";
                }
                );
        }
    }
}
