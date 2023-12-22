using ApplicationLayer.DTO;
using DomainLayer.Enities;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface IOrderService
    {
        Task<OrderRes>AddOrderAsync(int cusId,OrderReqModel order);
        Task<List<Order>> GetOrdersAsync(int custId);
        Task<OrderRes> GetOrdersByIdAsync(int custid, int Orderid);
        int DeleteOrderById(int customerId,int id);
    }
}
