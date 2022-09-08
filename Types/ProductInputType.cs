using GraphQL.Types;

namespace GraphQLProjectCode.Types
{
    public class ProductInputType : InputObjectGraphType
    {
        public ProductInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<FloatGraphType>("price");
        }
    }
}
