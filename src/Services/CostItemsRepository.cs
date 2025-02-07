using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CostAnalyzer.Models;

namespace CostAnalyzer.Services
{
    public class CostItemsRepository
    {
        private const string ALL_TAG = "Wszystko";

        private ObservableCollection<CostItem> items = new ObservableCollection<CostItem>()
        {
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 12.59m,
                Description = "Biedronka - Kefir Biedronka - KefirBi edronka - KefirBiedr onka - KefirB iedronka - Kefir Biedro nka - Kefir",
                Tags = new string[] {"Zakupy", "Moda"}
            },
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 1023.23m,
                Description = "Biedronka - kefir",
                Tags = new string[] {"Zakupy", "Jedzenie"}
            },
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 12.5m,
                Description = "Biedronka - Kefir",
                Tags = new string[] {"Zakupy"}
            }
        };
        public void AddItem(CostItem item)
        {
            item.Id = Guid.NewGuid();
            items.Add(item);
        }
        public CostItem GetItemById(Guid id) => items.FirstOrDefault(x => x.Id.Equals(id));
        public IEnumerable<CostItem> GetItems() => items;
        public IEnumerable<CostItem> GetItems(string tagFilter) => string.IsNullOrEmpty(tagFilter) || tagFilter.Equals(ALL_TAG)
            ? items
            : items.Where(x => x.Tags.Contains(tagFilter));
        public void EditItem(Guid id, CostItem model)
        {
            var item = GetItemById(id);
            item.Description = model.Description;
            item.Tags = model.Tags;
            item.Cost = model.Cost;
        }
        public void RemoveItem(Guid id) => items.Remove(GetItemById(id));

        public decimal GetItemsCost(string selectedTag) => GetItems(selectedTag).Sum(x => x.Cost);
        public IEnumerable<string> UsedTags => items.SelectMany(x => x.Tags).Distinct().Prepend(ALL_TAG);
    }
}