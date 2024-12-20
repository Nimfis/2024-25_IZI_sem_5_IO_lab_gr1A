namespace CostAnalyzer.Models
{
    public class CostItem
    {
        public string Description { get; set; }

        public decimal Cost { get; set; } 
        public string[] Tags { get; set; }
    }
}