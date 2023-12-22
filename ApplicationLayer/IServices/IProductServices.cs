
using ApplicationLayer.DTO;
using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
   public interface IProductServices
    {
        public List<ProductDto> GetProduct();
        public ProductDto GetProductById(int id);
        public ProductDto AddProduct(ProductAddModel product);
        public ProductDto UpdateProduct(int id, ProductAddModel productDto);
        public int DeleteProductById(int id);
    }
}
