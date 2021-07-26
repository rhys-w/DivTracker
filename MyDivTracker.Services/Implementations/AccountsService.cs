using MyDivTracker.Data;
using MyDivTracker.Data.Interfaces;
using MyDivTracker.Services.Dtos.Accounts;
using MyDivTracker.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDivTracker.Services.Implementations
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountsService(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public async Task<IEnumerable<AccountDto>> GetAccountsAsync()
        {
            var accounts = await _accountsRepository.GetAccountsAsync();

            // TODO - Map. (add a mapper)
            var mappedAccounts = new List<AccountDto>();
            foreach(var account in accounts)
            {
                var dto = new AccountDto
                {
                    Id = account.Id,
                    Name = account.Name,
                    Description = account.Description,
                    IsIsa = account.IsIsa
                };
                mappedAccounts.Add(dto);
            }
            
            return mappedAccounts;
        }

        public async Task CreateAccountAsync(AccountCreateDto createDto)
        {
            // TODO - Map. (add a mappper)
            var account = new Account
            {
                Name = createDto.Name,
                Description = createDto.Description,
                IsIsa = createDto.IsIsa
            };
            await _accountsRepository.InsertAndSaveAsync(account);
        }
    }
}
