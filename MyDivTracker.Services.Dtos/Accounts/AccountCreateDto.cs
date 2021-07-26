using System.ComponentModel.DataAnnotations;

namespace MyDivTracker.Services.Dtos.Accounts
{
    public class AccountCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsIsa { get; set; }
    }
}
