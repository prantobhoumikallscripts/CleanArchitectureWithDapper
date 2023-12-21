using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface ICustomerRepository
    {
        Customer GetCustomerWithDetails(int id);

        IEnumerable<Customer> GetCustomers();

        CustomerAddModel AddCustomer(CustomerAddModel customer);

        int DeleteCustomer(int id);




    }
}
