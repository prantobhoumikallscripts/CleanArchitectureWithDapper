using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Context
{
    public class DataContext:DbContext
    {
        private readonly IConfiguration _configuration;
       
      
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseSqlServer("Server=.;Database=DemoDb;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}
