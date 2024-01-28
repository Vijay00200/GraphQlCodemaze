using System;
using GraphQL.DataLoader;
using GraphQL.Types;
using GraphQlCodemaze.Contracts;
using GraphQlCodemaze.Entities;

namespace GraphQlCodemaze.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository, IDataLoaderContextAccessor dataLoader)
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(x => x.Name).Description("Name property from the owner object.");
            Field(x => x.Address).Description("Address property from the owner object.");
            Field<ListGraphType<AccountType>>(
            "accounts",
            resolve: context =>
            {
                // here we are storing the id and pass it to the IN db query
                var loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>("GetAccountsByOwnerIds", repository.GetAccountsByOwnerIds);
                return loader.LoadAsync(context.Source.Id);
            });
            // if we do as below it will execute the resolver foreach Owner , too many db call
            // Field<ListGraphType<AccountType>>(
            //     "accounts",
            //     resolve: context => repository.GetAllAccountsPerOwner(context.Source.Id)
            // );
        }
    }
}
