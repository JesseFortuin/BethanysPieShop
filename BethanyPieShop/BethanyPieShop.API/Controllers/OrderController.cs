using BethanyPieShop.Application;
using BethanyPieShop.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderFacade orderFacade;

        public OrderController(IOrderFacade orderFacade)
        {
            this.orderFacade = orderFacade;
        }

        [HttpGet("{orderId}")]
        public ActionResult<ApiResponseDto<OrderDto>> GetOrderById(int orderId)
        {
            var result = orderFacade.getOrderById(orderId);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<ApiResponseDto<bool>> AddOrder([FromForm]OrderDto orderDto) 
        {
            var result = orderFacade.AddOrder(orderDto);

            return Ok(result);
        }
    }
}
