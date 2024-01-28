using System;
using GraphQlCodemaze.Contracts;
using GraphQlCodemaze.Entities;
using GraphQlCodemaze.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace GraphQlCodemaze.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId) => _context.Accounts
            .Where(a => a.OwnerId.Equals(ownerId))
            .ToList();


        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(a=> ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(x=> x.OwnerId);
        }

    }
}
