using ApplicationLayer.DTO;
using ApplicationLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        public readonly ILogger<ProductController> _logger;
        public readonly IProductServices _productServices;
        public ProductController(ILogger<ProductController> logger, IProductServices productServices)
        {

            _logger = logger;
            _productServices = productServices;

        }
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProduct()
        {

            var res = _productServices.GetProduct();
            if (res == null)
            {
                return NoContent();
            }
            return Ok(res);
        }

        //get product by id

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>> GetProductbyId(int id)
        {
            var product = _productServices.GetProductById(id);
            return product == null ? NotFound("Id Not Found") : Ok(product);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productDto"></param>
        /// <returns></returns>
        
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProductbyId(int id, [FromBody] ProductDto productDto)
        {
            if (id == 0 || productDto is null)
            {
                return BadRequest();
            }
            var res = _productServices.UpdateProduct(id, productDto);
            if (res is null)
            {
                return NotFound("Id not Found");
            }
            return res;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProductbyId(int id)
        {
            if (id == 0)
            {
                return BadRequest("id can not be 0");
            }
            var res = _productServices.DeleteProductById(id);
            if (res == 0)
            {
                return NotFound("Id not Found");
            }
            return Ok(res);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost()]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductDto>> CreateProduct(ProductDto product)
        {
            if (product == null)
            {
                return BadRequest(" Product can't be Null");
            }
            var res = _productServices.AddProduct(product);

            return CreatedAtAction(nameof(GetProduct), new { Massage = "Productcreated "}, product) ;
        }

    }
}
