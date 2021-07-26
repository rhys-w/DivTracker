using System;

namespace MyDivTracker.Services.Dtos.Accounts
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsIsa { get; set; }
    }
}
