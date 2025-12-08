using System;
using WebApplicationMVC.Models.Models;

namespace WebApplicationMVC.Interfaces.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(string customerName, string statusName);
    }

}
