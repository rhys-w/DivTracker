using Microsoft.EntityFrameworkCore;
using MyDivTracker.Data.EFCore.DBContexts;
using MyDivTracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDivTracker.Data.EFCore.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly MyDivTrackerDbContext _myDivTrackerDbContext;

        public AccountsRepository(MyDivTrackerDbContext myDivTrackerDbContext)
        {
            _myDivTrackerDbContext = myDivTrackerDbContext;
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _myDivTrackerDbContext.Accounts
                .ToListAsync();
        }

        public async Task<Account> GetAccountAsync(Guid accountId)
        {
            return await _myDivTrackerDbContext.Accounts.FirstOrDefaultAsync(acc => acc.Id == accountId);
        }

        public async Task InsertAndSaveAsync(Account account)
        {
            if (account == null) throw new ArgumentNullException();
            _myDivTrackerDbContext.Accounts.Add(account);
            await _myDivTrackerDbContext.SaveChangesAsync();
        }
    }
}