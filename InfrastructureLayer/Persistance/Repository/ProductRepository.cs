
using DomainLayer;
using DomainLayer.Interface.Repository;
using InfrastructureLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Persistance.Repository
{
    public class ProductRepository : IProductRepository {

        private readonly DataContext _context;
      
        public ProductRepository(DataContext context)
        {
            _context = context;
            
        }

        public Product AddProduct(Product product)
        {
            if(product == null)
            {
                throw new ArgumentNullException(nameof(product));
            };
            _context.Products.Add(product);
            return product;
        }

        public int DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if(product == null)
            {
                return 0;
            };
            _context.Products.Remove(product);
           
            return id;
        }

        public Product? GetProduct(int id)
        {
           return _context.Products.Find(id);
            
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public int Save()
        {
           return _context.SaveChanges()>0?1:0;
        }

        public Product UpdateProduct(int id, Product product)
        {
            var res = _context.Products.Find(product.Id);
            if (res == null)
            {
                return null;
            };
            res.ProductName = product.ProductName;
            res.Description=product.Description;
            res.Price = product.Price;
            
            _context.Update(res);
            return res;
        }
    }
}
