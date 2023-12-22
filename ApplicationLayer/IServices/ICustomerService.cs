using ApplicationLayer.DTO;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface ICustomerService
    {

        List<AllCustomerResModel> GetCustomer();
        CustomerDetailsResModel CustomerById(int id);
        CustomerAddModel AddCustomer(CustomerReqModel customer);

        int DeleteCustomer(int id);
    }
}
