namespace Westpfälzer.Ui.ViewModels
{
    internal class ViewModelLocator
    {
        public CustomersViewModel CustomersViewModel { get; }
        public MainWindowViewModel MainWindowViewModel { get; }

        public ViewModelLocator()
        {
            CustomersViewModel = new CustomersViewModel();
            MainWindowViewModel = new MainWindowViewModel();
        }
    }
}
