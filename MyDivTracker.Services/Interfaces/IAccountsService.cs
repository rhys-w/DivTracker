using MyDivTracker.Services.Dtos.Accounts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDivTracker.Services.Interfaces
{
    public interface IAccountsService
    {
        Task<IEnumerable<AccountDto>> GetAccountsAsync();
        Task CreateAccountAsync(AccountCreateDto createDto);
    }
}
