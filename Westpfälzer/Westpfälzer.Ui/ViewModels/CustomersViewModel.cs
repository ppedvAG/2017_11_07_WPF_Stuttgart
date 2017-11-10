using System;
using System.Collections.Generic;
using System.Linq;
using Westpfälzer.Core;
using Westpfälzer.Core.Models;

namespace Westpfälzer.Ui.ViewModels
{
    internal class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomerRepository customerRepository;

        private IEnumerable<Customer> customers;
        public IEnumerable<Customer> Customers
        {
            get => customers;
            set
            {
                Set(ref customers, value);
                RaisePropertyChanged(nameof(CountCustomers));
            }
        }

        public int? CountCustomers => Customers?.Count();

        public Command LoadCustomersCommand { get; }

        public CustomersViewModel(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));

            LoadCustomersCommand = new Command(
                async () => Customers = (await customerRepository.GetAll()).OrderBy(c => c.Firstname),
                () => Customers is null);
        }
    }
}
