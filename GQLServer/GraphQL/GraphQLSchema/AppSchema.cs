using System;
using GraphQL.Types;
using GraphQlCodemaze.GraphQL.GraphQLQueries;

namespace GraphQlCodemaze.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
            Mutation = provider.GetRequiredService<AppMutation>();
        }
    }
}
