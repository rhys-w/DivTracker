using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDivTracker.Data
{
    public class Ticker : EntityBase
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Symbol { get; set; }

        [Required]
        public bool IsETF { get; set; }

        [Required]
        public string Location { get; set; }

        public ICollection<Dividend> Dividends { get; set; } = new List<Dividend>();
    }
}
