using Dapper;
using DomainLayer.Enities;
using DomainLayer.Interface;
using DomainLayer.Models;
using InfrastructureLayer.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InfrastructureLayer.Persistance.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
  
        private readonly IDbConnection _connection;
        public CustomerRepository(DapperContext context)
        {
            
          _connection = context.CreateConnection();
        }
        
        
        public CustomerAddModel AddCustomer(CustomerAddModel customer)
        {
            using (var txScope = new TransactionScope())
            {
                CustomerAddModel res= new CustomerAddModel();
                // string query = "Insert into Customers ( FullName, Email,PhoneNumber,Address,DOB,Gender,RegionId) Values ( @FullName,@Email,@PhoneNumber,@Address,@DOB,@Gender,@RegionId)" +
                //"Select Cast(SCOPE_IDENTITY() as Int)";
                
                var parameters = new DynamicParameters();
                parameters.Add("Id", DbType.Int32,direction: ParameterDirection.Output);
                parameters.Add("FullName", customer.FullName, DbType.String);
                parameters.Add("PhoneNumber", customer.PhoneNumber, DbType.String);
                parameters.Add("Email", customer.Email, DbType.String);
                parameters.Add("Address", customer.Address, DbType.String);
                parameters.Add("DOB", customer.DOB, DbType.DateTime);
                parameters.Add("Gender", customer.Gender.ToString(), DbType.String);
                parameters.Add("RegionId", customer.RegionId, DbType.Int32);

                _connection.Query("spInsertCustomer", parameters,commandType:CommandType.StoredProcedure);
                int customerId = parameters.Get<int>("Id");
                if (customerId > 0)
                {
                    customer.AccountDetails.CustomerId = customerId;
                    var p = new DynamicParameters();
                    p.Add("id", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    p.Add("BankName", customer.AccountDetails?.BankName, DbType.String);
                    p.Add("BranchName", customer.AccountDetails?.BranchName, DbType.String);
                    p.Add("Balance", customer.AccountDetails?.Balance, DbType.Int32);
                    p.Add("CustomerId", customerId, DbType.Int32);
                    _connection.Query("spInsertAccount", p,commandType:CommandType.StoredProcedure);

                    int accNo = p.Get<int>("id");
                   

                    //var accNo = _connection.Query<int>("spInsertAccount", customer.AccountDetails, commandType: CommandType.StoredProcedure).Single();
                    if (accNo > 0)
                    {
                        customer.AccountDetails.AccountNo = accNo;
                    }
                    res = customer;
                }

                txScope.Complete();
               return res; ;

            }
           
            
        }

        public CustomerDetailsResModel GetCustomerWithDetails(int id)
        {
            //string query = "SELECT * FROM Customers WHERE Id = @id";
            //using (var connection = _context.CreateConnection())
            //{
            //    var product = connection.QueryFirstOrDefault<Customer>(query, new { id });
            //    return product;
            //}

            // var cus= _connection.QueryFirstOrDefault<Customer>(query, new {id});

            //var cus = _connection.Query<Customer>("spGetCustomerById", new {id},commandType:CommandType.StoredProcedure).SingleOrDefault();


            //var acc= _connection.QueryFirstOrDefault<Account>("SELECT * FROM Accounts WHERE CustomerId = @id", new {id});
            //if (acc != null && cus != null)
            //{
            //    cus.AccountDetails = acc;
            //}
            var param =new DynamicParameters();
            param.Add("id", id);

            //var cus =(_connection.Query<Customer, Account, Customer>("spGetCustomerDetailsById", 
            //    (cus, acc) => { cus.AccountDetails = acc; return cus; }, 
            //    param,commandType:CommandType.StoredProcedure,splitOn: "AccountNo")).FirstOrDefault();



            //var orders = _connection.Query<Order>("spGetAllOrderOfCustomer", new { id },commandType:CommandType.StoredProcedure);



            //if (orders!=null && cus!=null)
            //{
            //    cus.Orders.AddRange(orders);
            //}



            var customerDictionary = new Dictionary<int, CustomerDetailsResModel>();
            // Query with multi-mapping
            var result = _connection.Query<CustomerDetailsResModel, Account, Order, CustomerDetailsResModel>(
                    sql: "[dbo].[spGetCustomerDetailsById]",
                    map: (customer, account, order) =>
                    {
                        if (!customerDictionary.TryGetValue(customer.Id, out var existingCustomer))
                        {
                            existingCustomer = customer;
                            existingCustomer.AccountDetails = account;
                            existingCustomer.Orders = new List<Order>();
                            customerDictionary.Add(existingCustomer.Id, existingCustomer);
                        }

                        if (order != null)
                            existingCustomer.Orders.Add(order);

                        return existingCustomer;
                    },
                    param ,splitOn: "AccountNo, Id",commandType:CommandType.StoredProcedure);
                 var cus = result.FirstOrDefault();
                return cus;
           
        }

        public IEnumerable<CustomerDetailsResModel> GetCustomers()
        {
            // string query = "SELECT * FROM Customers";
            //using (var connection = _context.CreateConnection())
            //{
            //    var product = connection.Query<Customer>(query);
            //    return product.ToList();
            //}


            //return _connection.Query<Customer>(query).ToList();

             var res= _connection.Query<CustomerDetailsResModel>("spGetAllCustomer", commandType: CommandType.StoredProcedure);
            return res;

        }

        public int DeleteCustomer(int id)
        {
            int res = 0;
            // string query = " DELETE  FROM CustomerS WHERE Id = @id"; 
            // res = _connection.Execute(query, new { id });
             res  = _connection.Execute("spDeleteCustomer", new {id},commandType:CommandType.StoredProcedure);
           
            if (res > 0) { return id; }
            return res;
        }
    }
}
