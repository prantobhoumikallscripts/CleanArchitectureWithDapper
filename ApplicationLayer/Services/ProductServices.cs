
using ApplicationLayer.DTO;

using ApplicationLayer.IServices;
using ApplicationLayer.Services;
using AutoMapper;
using DomainLayer;
using DomainLayer.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationLayer.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductServices(IProductRepository productRepository, IMapper mapper)
        { 
            _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(_productRepository));

        }
        public ProductDto AddProduct(ProductDto productDto)
        {   
            var product1= _mapper.Map<Product>(productDto);

            //var product = new Product
            //{
            //    AvilableQantity = productDto.AvilableQantity,
            //    SoldQuantity = productDto.SoldQuantity,
            //    Description = productDto.Description,
            //    ProductName = productDto.ProductName,
            //    Price = productDto.Price
            //};

            var res = _productRepository.AddProduct(product1);
            return productDto;
        }

        public int DeleteProductById(int id)
        {
            var res=_productRepository.DeleteProduct(id);
            if (res > 0) {
                _productRepository.Save();
            }
                
            return res;
        }

        public List<ProductDto> GetProduct()
        {
          var products= _productRepository.GetProducts();
          
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            //foreach (var product in products)
            //{
            //    var productDto = new ProductDto
            //    {
            //        AvilableQantity = product.AvilableQantity,
            //        SoldQuantity = product.SoldQuantity,
            //        Description = product.Description,
            //        ProductName = product.ProductName,
            //        Price = product.Price
            //    };
            //    productDtos.Add(productDto);

            //}
            return productDtos;
        }

        public ProductDto? GetProductById(int id)
        {
           var product= _productRepository.GetProduct(id);
            if(product == null)
            {
                return null;
            };
            var productDto = _mapper.Map<ProductDto>(product);
            //var productDto = new ProductDto
            //{
            //    AvilableQantity = product.AvilableQantity,
            //    SoldQuantity = product.SoldQuantity,
            //    Description = product.Description,
            //    ProductName = product.ProductName,
            //    Price = product.Price
            //};
            return productDto;
        }

        public ProductDto UpdateProduct(int id, ProductDto productDto)
        {
           
            var productToUpdate = _mapper.Map<Product>(productDto);
            productToUpdate.Id = id;
            var result = _productRepository.UpdateProduct(id,productToUpdate);
            var res = _mapper.Map<ProductDto>(result);
            return res;

        }
    }
}
