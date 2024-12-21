using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using CostAnalyzer.Models;

namespace CostAnalyzer.ViewModels
{
    class AddItemViewModel : ViewModelBase
    {
        public AddItemViewModel()
        {
            var valid = this.WhenAnyValue(
                m => m.Description,
                m => m.Cost, 
                (desc, cost) => !string.IsNullOrWhiteSpace(desc) && cost.HasValue);


            Ok = ReactiveCommand.Create(
                () => new CostItem
                {
                    Description = Description,
                    Cost = Cost ?? 0,
                    Tags = Tags?.Split(' ')
                },
                valid);
            Cancel = ReactiveCommand.Create(() => { });
        }

        string description;
        public string Description
        {
            get => description;
            set => this.RaiseAndSetIfChanged(ref description, value);
        }

        decimal? cost;
        public decimal? Cost
        {
            get => cost;
            set => this.RaiseAndSetIfChanged(ref cost, value);
        }

        string tags;
        public string Tags
        {
            get => tags;
            set => this.RaiseAndSetIfChanged(ref tags, value);
        }

        public ReactiveCommand<Unit, CostItem> Ok { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }
    }
}
