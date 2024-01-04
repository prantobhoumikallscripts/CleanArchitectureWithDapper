
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Context
{
    public class DapperContext
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly string _connection;
        public DapperContext(Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");
        }
        //public IDbConnection CreateConnection() => new SqlConnection(_connection);
        public IDbConnection CreateConnection()=>new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=DemoDB;Trusted_Connection=True;TrustServerCertificate=true");
    }
}
