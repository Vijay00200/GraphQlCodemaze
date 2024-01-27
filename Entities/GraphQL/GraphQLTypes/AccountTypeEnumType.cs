using System;
using GraphQL.Types;

namespace GraphQlCodemaze.Entities.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type"; // name value should match the property name used
            Description = "Enumeration for the account type object.";
        }
    }
}
