using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Models;

namespace DomainLayer.Interface
{
    public interface ICustomerRepository
    {
        CustomerDetailsResModel GetCustomerWithDetails(int id);

        IEnumerable<CustomerDetailsResModel> GetCustomers();

        CustomerAddModel AddCustomer(CustomerAddModel customer);

        int DeleteCustomer(int id);




    }
}
