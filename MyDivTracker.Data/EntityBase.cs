using System;
using System.ComponentModel.DataAnnotations;

namespace MyDivTracker.Data
{
    public abstract class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
