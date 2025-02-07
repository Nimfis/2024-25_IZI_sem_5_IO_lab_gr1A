using System.Collections.Generic;
using System.Linq;
using CostAnalyzer.Models;
using CostAnalyzer.Services;
using ReactiveUI;

namespace CostAnalyzer.ViewModels
{
    public class CostListViewModel : ViewModelBase
    {
        private readonly CostItemsRepository _repository;
        
        public CostListViewModel(CostItemsRepository repository)
        {
            _repository = repository;

            SelectedTag = Tags.FirstOrDefault();
            SelectedMonth = Months.FirstOrDefault();
        }

        IEnumerable<CostItem> items;
        public IEnumerable<CostItem> Items
        {
            get => _repository.GetItems(selectedTag, selectedMonth);
            set => this.RaiseAndSetIfChanged(ref items, value);
        }

        string selectedTag;
        public string SelectedTag
        {
            get => selectedTag;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedTag, value);
                UpdateList(value, selectedMonth);
            }
        }

        string selectedMonth;
        public string SelectedMonth
        {
            get => selectedMonth;
            set
            {
                this.RaiseAndSetIfChanged(ref selectedMonth, value);
                UpdateList(selectedTag, value);
            }
        }

        IEnumerable<string> tags;
        public IEnumerable<string> Tags
        {
            get => _repository.GetTagsFilters(selectedMonth);
            set
            {
                this.RaiseAndSetIfChanged(ref tags, value);
                SelectedTag = Tags.FirstOrDefault();
            }
        }

        IEnumerable<string> months;
        public IEnumerable<string> Months
        {
            get => _repository.GetMonthsFilters(selectedTag);
            set
            {
                this.RaiseAndSetIfChanged(ref months, value);
                SelectedMonth = months.FirstOrDefault();
            }
        }

        decimal costSum;
        public decimal CostSum
        {
            get => costSum = Sum;
            set => this.RaiseAndSetIfChanged(ref costSum, value);
        }

        public void ClearFilters()
        {
            Tags = _repository.GetTagsFilters(null);
            Months = _repository.GetMonthsFilters(null);
        }

        private void UpdateList(string tagFilter, string monthFilter)
        {
            Items = _repository.GetItems(tagFilter, monthFilter);
            CostSum = Sum;
        }

        private decimal Sum => _repository.GetItemsCost(SelectedTag, SelectedMonth);
    }
}