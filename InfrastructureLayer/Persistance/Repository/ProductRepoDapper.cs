
using Dapper;
using DomainLayer;
using DomainLayer.Interface.Repository;
using InfrastructureLayer.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Persistance.Repository
{
    public class ProductRepoDapper : IProductRepository
    {
        private readonly DapperContext _context;
        public ProductRepoDapper(DapperContext context) {
            _context = context;
        }
        public Product AddProduct(Product product)
        {
            string query = "Insert into Products (ProductName, Price,Description,ReleaseDate) Values (@ProductName,@Price,@Description,@ReleaseDate)";
            
            var parameters = new DynamicParameters();
            parameters.Add("Productname", product.ProductName,DbType.String);
            parameters.Add("Price", product.Price, DbType.Int32);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("ReleaseDate", product.ReleaseDate, DbType.DateTime);

            using (var connection = _context.CreateConnection())
            {
                connection.Execute(query, parameters);
                return product;
            }
        }

        public int DeleteProduct(int id)
        {
            int res = 0;
            string query = " DELETE  FROM PRODUCTS WHERE Id = @id";
            using (var connection = _context.CreateConnection())
            {
               res= connection.Execute(query, new { id });
   
            }
            if(res>0) { return id; }
            return res;
        }

        public Product GetProduct(int id)
        {
            string query = "SELECT * FROM PRODUCTS WHERE Id = @id";
            using (var connection = _context.CreateConnection())
            {
                var product = connection.QueryFirstOrDefault<Product>(query, new { id});
                return product;
            }

        }

        public IEnumerable<Product> GetProducts()
        {
            string query = "SELECT * FROM PRODUCTS";
            using (var connection = _context.CreateConnection())
            {
                var product = connection.Query<Product>(query);
                return  product.ToList();
            }

        }

        public int Save()
        {
            return 1;
        }

        public Product UpdateProduct(int id, Product product)

        {
            int res = 0;
            string query = "Update Products set ProductName=@ProductName,Price=@Price,Description=@Description,ReleaseDate=@ReleaseDate Where Id = @id ";
            var parameters = new DynamicParameters();
            parameters.Add("Id", product.Id, DbType.Int32);
            parameters.Add("Productname", product.ProductName, DbType.String);
            parameters.Add("Price", product.Price, DbType.Int32);
            parameters.Add("Description", product.Description, DbType.String);
            parameters.Add("ReleaseDate", product.ReleaseDate, DbType.DateTime);

            using (var connection = _context.CreateConnection())
            {
               res= connection.Execute(query, parameters);
                
            }
            if (res > 0) { return product; }
            return null;
        }

       
    }
}
