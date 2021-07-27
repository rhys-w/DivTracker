using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDivTracker.Data.Interfaces
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(Guid accountId);
        Task InsertAndSaveAsync(Account account);
    }
}
