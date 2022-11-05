using MediEval.Data.Services;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediEval.Controllers
{
    public class PharmacyBrandController : Controller
    {
        private readonly IPharmacyBrandService _service;

        public PharmacyBrandController(IPharmacyBrandService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allPharmacyBrands = await _service.GetAllAsync();
            return View(allPharmacyBrands);
        }

        //GET: PharmacyBrand/details/1
        public async Task<IActionResult> Details(int id)
        {
            var pharmacyBrandDetails = await _service.GetByIdAsync(id);
            if (pharmacyBrandDetails == null) return View("Not Found");
            return View(pharmacyBrandDetails);
        }

        //GET: PharmacyBrand/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,DosageForm,NDC_Code,category")] PharmacyBrand brand)
        {
            if (!ModelState.IsValid) return View(brand);

            await _service.AddAsync(brand);
            return RedirectToAction(nameof(Index));
        }

        //GET: PharmacyBrand/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var pharmacyBrandDetails = await _service.GetByIdAsync(id);
            if (pharmacyBrandDetails == null) return View("Not Found");
            return View(pharmacyBrandDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description,DosageForm,NDC_Code,category")] PharmacyBrand brand)
        {
            //if (!ModelState.IsValid) return View(brand);

            if (id == brand.ID)
            {
                await _service.UpdateAsync(id, brand);
                return RedirectToAction(nameof(Index));
            }
            return View(brand);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmacyBrandDetails = await _service.GetByIdAsync(id);
            if (pharmacyBrandDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
