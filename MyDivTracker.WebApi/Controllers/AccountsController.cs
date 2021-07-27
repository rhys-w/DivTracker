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
        public async Task<ActionResult<IEnumerable<AccountDto>>> GetAccountsAsync()
        {
            var accounts = await _accountsService.GetAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult<AccountDto>> GetAccountAsync(Guid accountId)
        {
            var account = await _accountsService.GetAccountAsync(accountId);

            if (account == null)
                return NotFound();

            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccountAsync([FromBody] AccountCreateDto createDto)
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
