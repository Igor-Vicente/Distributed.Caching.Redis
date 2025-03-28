using Demo.Api.Models;

namespace Demo.Api.Data.Repository
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(Order order);
        Task<Order?> GetOrderAsync(int id);
    }
    public class OrderRepository : IOrderRepository
    {
        private readonly DemoDbContext _context;

        public OrderRepository(DemoDbContext context)
        {
            _context = context;
        }

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<Order?> GetOrderAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }
    }
}
