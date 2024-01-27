using System;
using GraphQL.Types;
using GraphQlCodemaze.Entities.GraphQL.GraphQLQueries;

namespace GraphQlCodemaze.Entities.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
        }
    }
}
