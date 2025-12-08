using WebApplicationMVC.Interfaces.Interfaces;
using WebApplicationMVC.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext Context;

        public OrderService(ApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<Order> CreateOrderAsync(string customerName, string statusName)
        {
            // REQUIRED SEED DATA CHECK
            var status = await Context.OrderStatuses
                .FirstOrDefaultAsync(s => s.Name == statusName);

            if (status == null)
                throw new Exception("Required seed data status is missing.");

            var order = new Order
            {
                CustomerName = customerName,
                StatusId = status.Id
            };

            Context.Orders.Add(order);
            await Context.SaveChangesAsync();

            return order;
        }
    }

}
