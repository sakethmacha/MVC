using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService OrderService;

        public OrderController(IOrderService orderService)
        {
            OrderService = orderService;
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string customerName, string statusName)
        {
            try
            {
                var order = await OrderService.CreateOrderAsync(customerName, statusName);

                return Ok(new
                {
                    Message = "Order created successfully!",
                    OrderId = order.Id,
                    Status = order.StatusId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }


}
