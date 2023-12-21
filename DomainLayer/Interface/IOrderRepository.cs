using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IOrderRepository
    {
       Task<IEnumerable<Order>> GetAllOrderOfCustomerAsync(int id);
       Task<OrderRes> GetOrdersByIdAsync(int cusid,int id);
       Task<OrderRes> AddOrdersAsync(OrderAddModel order);
       int DeleteOrder(int id);
        int BulkOrderInsert();
    }
}
