using ApplicationLayer.DTO;
using ApplicationLayer.IServices;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        public readonly ILogger<CustomerController> _logger;
        public readonly ICustomerService _customerServices;
        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerServices)
        {

            _logger = logger;
            _customerServices = customerServices;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<List<AllCustomerResModel>>> GetAllCustomer()
        {

            var res = _customerServices.GetCustomer();
            if (res == null)
            {
                return NoContent();
            }
            return Ok(res);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<SingleCustomerResModel>> GetCustomerbyId(int id)
        {
            var customer = _customerServices.CustomerById(id);
            return customer == null ? NotFound("Id Not Found") : Ok(customer);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CustomerAddModel>> CreateCustomer(CustomerReqModel customer)
        {
            var res = _customerServices.AddCustomer(customer);
            return res == null ? NotFound("Id Not Found") : Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProductbyId(int id)
        {
            if (id == 0)
            {
                return BadRequest("id can not be 0");
            }
            var res = _customerServices.DeleteCustomer(id);
            if (res == 0)
            {
                return NotFound(" Customer Id not Found");
            }
            return Ok(res);
        }



    }
}
