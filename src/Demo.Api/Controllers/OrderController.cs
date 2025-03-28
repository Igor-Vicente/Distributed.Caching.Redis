using Demo.Api.Data.Repository;
using Demo.Api.Models;
using Demo.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICacheService _cacheService;

        public OrderController(IOrderRepository orderRepository, ICacheService cacheService)
        {
            _orderRepository = orderRepository;
            _cacheService = cacheService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var key = $":Order:{id}";
            var order = await _cacheService.GetRecordAsync<Order>(key);

            if (order == null)
            {
                order = await _orderRepository.GetOrderAsync(id);
                if (order != null)
                    await _cacheService.SetRecordAsync(key, order, DateTimeOffset.Now.AddMinutes(5));
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(AddOrderModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var order = new Order()
            {
                ClientId = model.ClientId,
                TotalPrice = model.TotalPrice,
                VoucherApplied = model.VoucherApplied,
                VoucherId = model.VoucherId,
            };

            await _orderRepository.AddOrderAsync(order);

            return Ok(order);
        }
    }
}
