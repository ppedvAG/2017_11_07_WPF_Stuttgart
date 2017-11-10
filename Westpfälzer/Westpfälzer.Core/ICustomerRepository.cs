using System.Collections.Generic;
using System.Threading.Tasks;
using Westpfälzer.Core.Models;

namespace Westpfälzer.Core
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();
    }
}
