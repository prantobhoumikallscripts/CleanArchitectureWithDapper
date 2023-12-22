
using ApplicationLayer.DTO;
using ApplicationLayer.IServices;
using DomainLayer.Enities;
using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PresentationLayer.Controllers
{
    [Route("api/{customerid}/Orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<List<Order>>>? GetAllOrderOfCustomer(int customerid)
        {
            try
            {
                IEnumerable<Order> value = await _orderService.GetOrdersAsync(customerid);
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderRes>>? GetOrderById(int customerid,int id)
        {
            try
            {
               OrderRes value = await _orderService.GetOrdersByIdAsync(customerid,id);
                if(value == null)
                {
                    return NotFound("No order with this ID");
                }
                return Ok(value);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<OrderRes>> CreateOrder( int customerid,[FromBody] OrderReqModel order)
        {
            try
            {
               // order.CustomerId = customerid;
                 var res = await _orderService.AddOrderAsync(customerid,order);
                return res == null ? NotFound("Id Not Found") : Created("GetOrderById", res);

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProductbyId(int customerid,int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("Order id can not be 0");
                }
                var res = _orderService.DeleteOrderById(customerid, id);
                if (res == 0)
                {
                    return NotFound($"Order with Id {id} Not Exist");
                }
                return Ok($"Order with Id {res} is deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
      


    }
}
