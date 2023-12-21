using ApplicationLayer.DTO;
using ApplicationLayer.IServices;
using AutoMapper;
using DomainLayer;
using DomainLayer.Interface;
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
        public CustomerAddModel? AddCustomer(CustomerAddModel customer)
        {
            
            return _cusRepository.AddCustomer(customer); 
           
        }

        public Customer CustomerById(int cusid)
        {
            var customer = _cusRepository.GetCustomerWithDetails(cusid);
            return customer;
        }

        public int DeleteCustomer(int id)
        {
            return (_cusRepository.DeleteCustomer(id));
        }

        public List<Customer> GetCustomer()
        {
            var cus = _cusRepository.GetCustomers();

           // var productDtos = _mapper.Map<List<ProductDto>>(products);
           return cus.ToList();
        }

     
    }
}
