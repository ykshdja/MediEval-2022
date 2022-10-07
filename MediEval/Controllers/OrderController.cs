using MediEval.Data;
using Microsoft.AspNetCore.Mvc;

namespace MediEval.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        public OrderController(AppDbContext context)
        {
            _context = context;
        }                                    
        public IActionResult Index()
        {
            var allOrders = _context.Orders.ToList();
            return View(allOrders);
        }
    }
}
