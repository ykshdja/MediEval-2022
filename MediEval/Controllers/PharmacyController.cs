using MediEval.Data;
using MediEval.Data.Services;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediEval.Controllers
{
    public class PharmacyController : Controller
    {

        private readonly IPharmacyServices _service;
        public PharmacyController(IPharmacyServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PharmName,PharmAddress,PharmPhone")] Pharmacy pharmacy)
        {
            if (!ModelState.IsValid)
            {
                return View(pharmacy);
            }
            await _service.AddAsync(pharmacy);
            return RedirectToAction(nameof(Index));
        }



    }
}
