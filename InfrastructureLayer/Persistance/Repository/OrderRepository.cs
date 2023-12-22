using Dapper;
using DomainLayer.Enities;
using DomainLayer.Interface;
using DomainLayer.Models;
using InfrastructureLayer.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InfrastructureLayer.Persistance.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DapperContext _context;
        public OrderRepository(DapperContext context)
        {
            _context = context;
        }

        
        public int BulkOrderInsert()
        {
            var connection=_context.CreateConnection();

            List<OrderAddModel> ordersToInsert = new List<OrderAddModel>
          {
            new OrderAddModel
            {
                Id = 1,
                ShippingAddress = "123 Main St",
                OrderDate = DateTime.Now,
                PaymentAmount = 100,
                DelivaryStatus = "Pending",
                PaymentDone = false,
                CustomerId = 29,
                ProductIDs = new List<int> { 1,  3 } // Example ProductIDs
            },
            new OrderAddModel
            {
                Id = 2,
                ShippingAddress = "456 Oak St",
                OrderDate = DateTime.Now,
                PaymentAmount = 150,
                DelivaryStatus = "Shipped",
                PaymentDone = true,
                CustomerId = 29,
                ProductIDs = new List<int> { 3, 4 } // Example ProductIDs
            },
              // Add more OrderAddModel objects as needed
          };

            // Call the BulkInsert method to perform the bulk insert and capture generated OrderIds
            var insertedOrderIds = BulkInsert(connection,ordersToInsert);

          return insertedOrderIds.Count();
        }

        



        public async Task<OrderRes> AddOrdersAsync(OrderAddModel order)
        {
            var res=new OrderRes();
            var _connection = _context.CreateConnection();
            try
            {
                 //  string query = "Insert into Orders (ShippingAddress ,OrderDate,PaymentAmount,DelivaryStatus,PaymentDone,CustomerId) VALUES (@ShippingAddress,@orderdate,@PaymentAmount,@DelivaryStatus,@PaymentDone,@CustomerId)"+
                 //               "Select Cast(SCOPE_IDENTITY() as Int)";

                _connection.Open();
                //var id = _connection.Query<int>(query, order).Single();
                var parameters = new DynamicParameters();
                parameters.Add("Id", DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("ShippingAddress", order.ShippingAddress, DbType.String);
                parameters.Add("DelivaryStatus", order.DelivaryStatus, DbType.String);
                parameters.Add("PaymentDone", order.PaymentDone, DbType.Boolean);
                parameters.Add("PaymentAmount", order.PaymentAmount, DbType.Int32);
                parameters.Add("OrderDate", order.OrderDate, DbType.DateTime);
                parameters.Add("CustomerId", order.CustomerId, DbType.Int32);

               
                _connection.Execute("spInsertorder",parameters, commandType: CommandType.StoredProcedure);

                var id = parameters.Get<int>("Id");
                if (id > 0)
                {
                    order.Id = id;
                    foreach (var productId in order.ProductIDs)
                    {
                        await _connection.ExecuteAsync("spInsertOrderedProduct", new {orderId=id,productId}, commandType: CommandType.StoredProcedure);
                    }
                    res= await _connection.QueryFirstOrDefaultAsync<OrderRes>("spGetOrderById", new {cusid=order.CustomerId, id }, commandType: CommandType.StoredProcedure);

                }
            }
            finally
            {
                _connection.Close();
            }
            return res ;

        }

        public async Task<IEnumerable<Order>> GetAllOrderOfCustomerAsync(int id)
        {
            
            using (var connection = _context.CreateConnection())
            {
                var product = await connection.QueryAsync<Order> ("spGetAllOrderOfCustomer", new {id},commandType:CommandType.StoredProcedure);
                return product.ToList();
            }
        }

        public async Task<OrderRes?>   GetOrdersByIdAsync(int cusid ,int id)
        {


            //using (var connection = _context.CreateConnection())
            //{
            //    var orderRes = await connection.QueryFirstOrDefaultAsync<OrderRes>("SELECT * FROM Orders Where CustomerId=@cusid and Id=@id", new { cusid, id = id });
            //    var products = await connection.QueryAsync<Product>("SELECT p.* From Products p inner Join OrderedProduct cl on p.Id=cl.ProductId inner join Orders o on cl.OrderId=o.Id where  o.id=@id;", new { id });
            //    if (products != null && orderRes != null)
            //        orderRes.Products.AddRange(products);

            //    return orderRes;
            //}
            var orderDictionary = new Dictionary<int, OrderRes>();
            var connection = _context.CreateConnection();
            var orders = await connection.QueryAsync<OrderRes, Product, OrderRes>("spGetOrderDetailsById",
                (order, product) =>
                {
                    if (!orderDictionary.TryGetValue(order.Id, out var existingOrder))
                    {
                        existingOrder = order;
                        existingOrder.Products = new List<Product>();
                        orderDictionary.Add(existingOrder.Id, existingOrder);
                    }
                    if(product!=null)
                    existingOrder.Products.Add(product);

                    return existingOrder;


                }, new { id }, commandType: CommandType.StoredProcedure);

           
            return orders.FirstOrDefault();




        }

        public int DeleteOrder(int id)
        {
            int res = 0;
            using (var connection = _context.CreateConnection())
            {
                res = connection.Execute("spDeleteOrderById", new { id }, commandType: CommandType.StoredProcedure);

            }
            if (res > 0) { return id; }
            return res;
        }

        static IEnumerable<int> BulkInsert(IDbConnection connection, IEnumerable<OrderAddModel> orders)
        {

            IEnumerable<int> insertedOrderIds = new List<int>();


            connection.Open();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@Orders", GetDataTable(orders), DbType.Object);

                    // Execute stored procedure for inserting orders and capturing generated OrderIds
                    insertedOrderIds = connection.Query<int>("spBulkInsertOrder", dynamicParameters, transaction, commandType: CommandType.StoredProcedure);

                    var ordersList = orders.ToList();
                    for (int i = 0; i < ordersList.Count; i++)
                    {
                        ordersList[i].Id = insertedOrderIds.ElementAtOrDefault(i);
                    }

                    // Insert associated order products
                    foreach (var orderId in insertedOrderIds)
                    {
                        foreach (var productId in ordersList.First(o => o.Id == orderId).ProductIDs)
                        {
                            connection.Execute("spInsertOrderedProduct", new { orderId = orderId, productId = productId }, transaction, commandType: CommandType.StoredProcedure);
                        }
                    }

                    // Commit the transaction
                    transaction.Commit();
                  

                }
                catch (Exception ex)
                {
                    // Handle exceptions and roll back the transaction on error
                    transaction.Rollback();
                   

                    // Return an empty list in case of an error

                }
            }
            connection.Close();
            return insertedOrderIds;



        }


        static DataTable GetDataTable(IEnumerable<OrderAddModel> orders)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("ShippingAddress", typeof(string));
            dataTable.Columns.Add("OrderDate", typeof(DateTime));
            dataTable.Columns.Add("PaymentAmount", typeof(int));
            dataTable.Columns.Add("DelivaryStatus", typeof(string));
            dataTable.Columns.Add("PaymentDone", typeof(bool));
            dataTable.Columns.Add("CustomerId", typeof(int));

            foreach (var order in orders)
            {
                dataTable.Rows.Add(order.Id, order.ShippingAddress, order.OrderDate, order.PaymentAmount, order.DelivaryStatus, order.PaymentDone, order.CustomerId);
            }

            return dataTable;
        }
    }
}

