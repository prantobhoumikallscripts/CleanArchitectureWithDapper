using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface ICustomerService
    {

        List<Customer> GetCustomer();
        Customer CustomerById(int id);
        CustomerAddModel AddCustomer(CustomerAddModel customer);

        int DeleteCustomer(int id);
    }
}
