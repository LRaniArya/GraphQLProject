using GraphQL.Types;
using GraphQLProjectCode.Mutation;
using GraphQLProjectCode.Queries;

namespace GraphQLProjectCode.Schema
{
    public class ProductSchema : GraphQL.Types.Schema
    {
        public ProductSchema( ProductQuery productQuery, ProductMutation productMutation) 
        {
            Query = productQuery;
            Mutation = productMutation;
        }

    }
}
