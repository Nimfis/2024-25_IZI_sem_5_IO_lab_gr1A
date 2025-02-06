using System;
using System.Reactive.Linq;
using ReactiveUI;
using CostAnalyzer.Models;
using CostAnalyzer.Services;
using System.Linq;

namespace CostAnalyzer.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        private readonly CostItemsRepository _repository;

        public MainWindowViewModel(CostItemsRepository repository)
        {
            _repository = repository;
            Content = List = new CostListViewModel(_repository);
        }

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public CostListViewModel List { get; }

        public void AddItem()
        {
            var vm = new AddItemViewModel();

            Observable.Merge(
                    vm.Ok,
                    vm.Cancel.Select(_ => (CostItem)null))
                //.Take(1)
                .Subscribe(model =>
                {
                    if (model != null)
                    {
                        _repository.AddItem(model);
                    }

                    Content = List;
                });

            Content = vm;
        }

        public void RemoveItem(Guid id) => _repository.RemoveItem(id);
    }
}