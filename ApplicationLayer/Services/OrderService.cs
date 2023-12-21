using ApplicationLayer.DTO;
using ApplicationLayer.IServices;
using DomainLayer;
using DomainLayer.Interface;
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
        public OrderService(ICustomerRepository customerRepository,IOrderRepository orderRepository) {
            _cusRepo = customerRepository;
            _orderRepo = orderRepository;
        }

        public Task<OrderRes> AddOrderAsync(OrderAddModel order)
        {
            var cus = _cusRepo.GetCustomerWithDetails(order.CustomerId);
            if (cus == null)
            {
                throw new ArgumentException("customer not found");

            }
             var res  =  _orderRepo.BulkOrderInsert();
            return _orderRepo.AddOrdersAsync(order);
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
