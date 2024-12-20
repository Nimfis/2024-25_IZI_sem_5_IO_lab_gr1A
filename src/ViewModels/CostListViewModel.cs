using System.Collections.Generic;
using System.Collections.ObjectModel;
using CostAnalyzer.Models;

namespace CostAnalyzer.ViewModels
{
    public class CostListViewModel : ViewModelBase
    {
        public CostListViewModel(IEnumerable<CostItem> items)
        {
            Items = new ObservableCollection<CostItem>(items);
        }

        public ObservableCollection<CostItem> Items { get; }
    }
}