using System.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }
        IEnumerable<CostItem> items;
        public IEnumerable<CostItem> Items
        {
            get => _repository.GetItems(selectedTag);
            set => this.RaiseAndSetIfChanged(ref items, value);
        }
        //public IEnumerable<CostItem> Items => _repository.GetItems(selectedTag);
        string selectedTag;
        public string SelectedTag
        {
            get => selectedTag;
            set
            {
                /*var tags = _repository.UsedTags;
                var newSelectedTag = tags.Contains(value) ? value :tags.FirstOrDefault();*/
                this.RaiseAndSetIfChanged(ref selectedTag, value);
                Items = _repository.GetItems(value);
                CostSum = Sum;
            }
        }
        IEnumerable<string> tags;
        public IEnumerable<string> Tags
        {
            get => _repository.UsedTags;
            set
            {
                this.RaiseAndSetIfChanged(ref tags, value);
                SelectedTag = Tags.FirstOrDefault();
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
      
            Tags = _repository.UsedTags;
        }

        private decimal Sum => _repository.GetItemsCost(SelectedTag);
    }
}