using System.Collections.Generic;
using CostAnalyzer.Models;

namespace CostAnalyzer.Services
{
    public class CostItemsRepository
    {
        public IEnumerable<CostItem> GetItems() => new[]
        {
            new CostItem()
            {
                Cost = 12.59m,
                Description = "Biedronka - Kefir Biedronka - KefirBi edronka - KefirBiedr onka - KefirB iedronka - Kefir Biedro nka - Kefir",
                Tags = new string[] {"Zakupy", "Jedzenie"}
            },
            new CostItem()
            {
                Cost = 1023.23m,
                Description = "Biedronka - Kefir",
                Tags = new string[] {"Zakupy", "Jedzenie"}
            },
            new CostItem()
            {
                Cost = 12.5m,
                Description = "Biedronka - Kefir",
                Tags = new string[] {"Zakupy", "Jedzenie"}
            }
        };
    }
}