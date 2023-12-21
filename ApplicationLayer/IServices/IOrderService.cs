using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface IOrderService
    {
        Task<OrderRes>AddOrderAsync(OrderAddModel order);
        Task<List<Order>> GetOrdersAsync(int custId);
        Task<OrderRes> GetOrdersByIdAsync(int custid, int Orderid);
        int DeleteOrderById(int customerId,int id);
    }
}
