using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDivTracker.Data.Interfaces
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task InsertAndSaveAsync(Account account);
    }
}
