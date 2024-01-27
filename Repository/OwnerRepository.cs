using System;
using GraphQlCodemaze.Contracts;
using GraphQlCodemaze.Entities;
using GraphQlCodemaze.Entities.Context;

namespace GraphQlCodemaze.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll() => _context.Owners.ToList();

        public Owner GetById(Guid id) => _context.Owners.SingleOrDefault(o=> o.Id.Equals(id));

    }
}
