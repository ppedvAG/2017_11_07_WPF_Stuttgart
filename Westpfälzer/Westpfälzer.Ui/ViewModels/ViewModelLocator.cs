using StructureMap;
using Westpfälzer.Core;
using Westpfälzer.Data;

namespace Westpfälzer.Ui.ViewModels
{
    internal class ViewModelLocator
    {
        private readonly IContainer container;

        public CustomersViewModel CustomersViewModel => container.GetInstance<CustomersViewModel>();
        public MainWindowViewModel MainWindowViewModel => container.GetInstance<MainWindowViewModel>();

        public ViewModelLocator()
        {
            container = new Container(c =>
            {
                c.For<ICustomerRepository>().Use<CustomerRepository>();
            });
        }
    }
}
