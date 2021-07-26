using Microsoft.AspNetCore.Mvc;
using MyDivTracker.Services.Dtos.Accounts;
using MyDivTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyDivTracker.WebApi.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountsService;

        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService ?? throw new ArgumentNullException(nameof(accountsService));
        }

        [HttpGet]
        public async Task<IEnumerable<AccountDto>> GetAccounts()
        {
            var accs = await _accountsService.GetAccountsAsync();
            return accs;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _accountsService.CreateAccountAsync(createDto);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
