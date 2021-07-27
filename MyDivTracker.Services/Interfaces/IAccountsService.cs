using MyDivTracker.Services.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDivTracker.Services.Interfaces
{
    public interface IAccountsService
    {
        Task<IEnumerable<AccountDto>> GetAccountsAsync();
        Task<AccountDto> GetAccountAsync(Guid accountId);
        Task CreateAccountAsync(AccountCreateDto createDto);
    }
}
