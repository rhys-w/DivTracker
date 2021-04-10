using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDivTracker.Data
{
    public class Account : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public bool IsIsa { get; set; }

        public ICollection<Dividend> Dividends { get; set; } = new List<Dividend>();
    }
}
