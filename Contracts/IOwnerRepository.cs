using System;
using GraphQlCodemaze.Entities;

namespace GraphQlCodemaze.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner GetById(Guid id);
    }
}
