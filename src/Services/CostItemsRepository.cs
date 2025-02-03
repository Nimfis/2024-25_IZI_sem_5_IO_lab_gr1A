using System;
using System.Collections.Generic;
using System.Linq;
using CostAnalyzer.Models;

namespace CostAnalyzer.Services
{
    public class CostItemsRepository
    {
        private List<CostItem> items = new List<CostItem>()
        {
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 12.59m,
                Description = "Biedronka - Kefir Biedronka - KefirBi edronka - KefirBiedr onka - KefirB iedronka - Kefir Biedro nka - Kefir",
                Tags = new string[] {"Zakupy", "Jedzenie"}
            },
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 1023.23m,
                Description = "Biedronka - Kefir",
                Tags = new string[] {"Zakupy", "Jedzenie"}
            },
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 12.5m,
                Description = "Biedronka - Kefir",
                Tags = new string[] {"Zakupy", "Jedzenie"}
            }
        };
        public IEnumerable<CostItem> GetItems() => items;
        public CostItem GetItemById(Guid id) => items.FirstOrDefault(x => x.Id.Equals(id));
        public void AddItem(CostItem item) => items.Add(item);
        public void RemoveItem(Guid id) => items.Remove(GetItemById(id));
    }
}