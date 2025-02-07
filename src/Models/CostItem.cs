using System;

namespace CostAnalyzer.Models
{
    public class CostItem
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; } 
        public string[] Tags { get; set; }
        public DateTime CreatedAt { get; set; }
        public string JoinedTags => string.Join(' ', Tags);
    }
}