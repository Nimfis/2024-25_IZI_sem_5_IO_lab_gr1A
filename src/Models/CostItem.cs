using System;

namespace CostAnalyzer.Models
{
    public class CostItem //TODO dodać daty i filtrowanie po datach (miesiacach sty 2001 itp??), ostyloować edd edit moze inny kolor??
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; } 
        public string[] Tags { get; set; }
        public string JoinedTags => string.Join(' ', Tags);
    }
}