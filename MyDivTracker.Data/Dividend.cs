using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDivTracker.Data
{
    public class Dividend : EntityBase
    {
        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public decimal AmountGBP { get; set; }

        [Required]
        public Guid TickerId { get; set; }

        [ForeignKey(nameof(TickerId))]
        public Ticker Ticker { get; set; }

        [Required]
        public Guid AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; }
    }
}
