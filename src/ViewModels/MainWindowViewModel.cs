using ReactiveUI;

namespace CostAnalyzer.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;

        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }
    }
}
