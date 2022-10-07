using MediEval.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MediEval.Controllers
{
    public class MedicineController : Controller
    {
        private readonly AppDbContext _context;
        public MedicineController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allMedicine = await _context.Medicines.Include(n => n.pharmaBrand).OrderBy(n => n.Name).ToListAsync();
            return View(allMedicine);
        }
    }
}
