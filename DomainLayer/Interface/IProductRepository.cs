using DomainLayer.Enities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface.Repository
{
    public interface IProductRepository
    {
        Product GetProduct(int id);

        IEnumerable<Product> GetProducts();

        Product AddProduct(Product product);
        Product UpdateProduct(int id,Product product);

        int DeleteProduct(int id);

        int Save();

    }
}
