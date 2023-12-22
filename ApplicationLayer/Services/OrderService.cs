using ApplicationLayer.DTO;
using ApplicationLayer.IServices;
using AutoMapper;
using DomainLayer.Enities;
using DomainLayer.Interface;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class OrderService : IOrderService
    {   
        private readonly IOrderRepository _orderRepo;
        private readonly ICustomerRepository _cusRepo;
        private readonly IMapper _mapper;
        public OrderService(ICustomerRepository customerRepository,IOrderRepository orderRepository,IMapper mapper) {
            _cusRepo = customerRepository;
            _orderRepo = orderRepository;
            _mapper = mapper;
        }

        public Task<OrderRes> AddOrderAsync(int cusId, OrderReqModel order)
        {
            var cus = _cusRepo.GetCustomerWithDetails(cusId);

            if (cus == null)
            {
                throw new ArgumentException("customer not found");

            }
            var orderToadd=_mapper.Map<OrderAddModel>(order);
            orderToadd.CustomerId= cusId;
            orderToadd.OrderDate=DateTime.Now;
            orderToadd.DelivaryStatus = "Pending";
           //  var res  =  _orderRepo.BulkOrderInsert();
            return _orderRepo.AddOrdersAsync(orderToadd);

        }

        public int DeleteOrderById(int customerId,int id)
        {

            var cus = _cusRepo.GetCustomerWithDetails(customerId);
            if (cus == null)
            {
                throw new ArgumentException("customer not found");
               

            }
            return _orderRepo.DeleteOrder(id);

        }

        public async Task<List<Order>> GetOrdersAsync(int cusid)
        {
           var cus = _cusRepo.GetCustomerWithDetails(cusid);
            if(cus == null)
            {
                throw new ArgumentException("customer not found");
                
            }
            
             var  orders= (List<Order>)await _orderRepo.GetAllOrderOfCustomerAsync(cusid);
            return orders;
        }


        public async Task<OrderRes> GetOrdersByIdAsync(int custid, int Orderid)
        {
            var cus = _cusRepo.GetCustomerWithDetails(custid);
            if (cus == null)
            {
                throw new ArgumentException("customer not found");

            }
            var orders = (OrderRes)await _orderRepo.GetOrdersByIdAsync(custid,Orderid);
            return orders;

        }
    }
}
