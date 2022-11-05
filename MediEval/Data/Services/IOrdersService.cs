using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediEval.Models;

namespace MediEval.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }
}
