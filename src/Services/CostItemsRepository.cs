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
        private const string ALL_MONTHS = "Zawsze";

        private ObservableCollection<CostItem> items = new ObservableCollection<CostItem>()
        {
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 12.59m,
                Description = "Biedronka - Kefir Biedronka - KefirBi edronka - KefirBiedr onka - KefirB iedronka - Kefir Biedro nka - Kefir",
                Tags = new string[] {"Zakupy", "Moda"},
                CreatedAt = DateTime.Now,
            },
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 1023.23m,
                Description = "Biedronka - kefir",
                Tags = new string[] {"Zakupy", "Jedzenie"},
                CreatedAt = DateTime.Now.AddDays(-60),
            },
            new CostItem()
            {
                Id = Guid.NewGuid(),
                Cost = 12.5m,
                Description = "Biedronka - Kefir",
                Tags = new string[] {"Zakupy"},
                CreatedAt= DateTime.Now.AddDays(-100),
            }
        };
        public void AddItem(CostItem item)
        {
            item.Id = Guid.NewGuid();
            item.CreatedAt = DateTime.Now;
            items.Add(item);
        }
        public CostItem GetItemById(Guid id) => items.FirstOrDefault(x => x.Id.Equals(id));
        public IEnumerable<CostItem> GetItems() => items;
        public IEnumerable<CostItem> GetItems(string tagFilter, string monthFilter)
        {
            IEnumerable<CostItem> query = items;
            if (!string.IsNullOrEmpty(tagFilter) && !tagFilter.Equals(ALL_TAG))
                query = query.Where(x => x.Tags.Contains(tagFilter));
            if (!string.IsNullOrEmpty(monthFilter) && !monthFilter.Equals(ALL_MONTHS))
                query = query.Where(x =>
                    DateTime.Parse(monthFilter).Year == x.CreatedAt.Year &&
                    DateTime.Parse(monthFilter).Month == x.CreatedAt.Month);
            return query;
        }
        public void EditItem(Guid id, CostItem model)
        {
            var item = GetItemById(id);
            item.Description = model.Description;
            item.Tags = model.Tags;
            item.Cost = model.Cost;
        }
        public void RemoveItem(Guid id) => items.Remove(GetItemById(id));

        public decimal GetItemsCost(string tagFilter, string monthFilter) => GetItems(tagFilter, monthFilter).Sum(x => x.Cost);
        public IEnumerable<string> GetTagsFilters(string monthFilter) => GetItems(null, monthFilter)
           .SelectMany(x => x.Tags)
           .Distinct()
           .Prepend(ALL_TAG);
        public IEnumerable<string> GetMonthsFilters(string tagFilter) => GetItems(tagFilter, null)
            .OrderByDescending(x => x.CreatedAt)
            //.Select(x => x.CreatedAt.ToString("Y"))
            .Select(x => x.CreatedAt.ToString("MMM yyyy"))
            .Distinct()
            .Prepend(ALL_MONTHS);
    }
}