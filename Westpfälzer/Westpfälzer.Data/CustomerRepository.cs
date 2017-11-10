using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tynamix.ObjectFiller;
using Westpfälzer.Core;
using Westpfälzer.Core.Models;

namespace Westpfälzer.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IEnumerable<Customer> customers;

        public CustomerRepository()
        {
            var addressFiller = new Filler<Address>();
            var addressSetup = addressFiller.Setup()
                .OnProperty(a => a.City).Use(new CityName())
                .OnProperty(a => a.Country).Use(new CountryName())
                .OnProperty(a => a.Street).Use(new StreetName())
                .OnProperty(a => a.ZipCode).Use(new PatternGenerator("{C:10000}"))
                .Result;

            var customerFiller = new Filler<Customer>();
            customerFiller.Setup()
                .OnProperty(c => c.Address).Use(addressSetup)
                .OnProperty(c => c.Firstname).Use(new RealNames(NameStyle.FirstName))
                .OnProperty(c => c.Lastname).Use(new RealNames(NameStyle.LastName))
                .OnProperty(c => c.Email).Use(new EmailAddresses(".de"));

            var random = new Random();
            customers = customerFiller.Create(random.Next(50, 500));
        }

        public Task<IEnumerable<Customer>> GetAll() => Task.FromResult(customers);
    }
}
