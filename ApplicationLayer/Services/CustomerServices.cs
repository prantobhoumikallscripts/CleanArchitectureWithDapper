using ApplicationLayer.DTO;
using ApplicationLayer.IServices;
using AutoMapper;
using DomainLayer.Interface;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class CustomerServices : ICustomerService
    {
        private readonly IMapper _mapper;

        private readonly ICustomerRepository _cusRepository;
        public CustomerServices(ICustomerRepository cusRepository,IMapper mapper)
        {
            _cusRepository = cusRepository;
            _mapper = mapper;
        }
        public CustomerAddModel? AddCustomer(CustomerReqModel customer)
        {

           var customerToAdd= _mapper.Map<CustomerAddModel>(customer);
            
            return _cusRepository.AddCustomer(customerToAdd); 
           
        }

        public CustomerDetailsResModel CustomerById(int cusid)
        {
            var customer = _cusRepository.GetCustomerWithDetails(cusid);
            return customer;
        }

        public int DeleteCustomer(int id)
        {
            return (_cusRepository.DeleteCustomer(id));
        }

        public List<AllCustomerResModel> GetCustomer()
        {
            var cus = _cusRepository.GetCustomers();

           var res = _mapper.Map<List<AllCustomerResModel>>(cus);
           return res;
        }

     
    }
}
