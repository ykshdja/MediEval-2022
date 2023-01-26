using MediEval.Data;
using MediEval.Data.Services;
using MediEval.Data.Static;
using MediEval.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MediEval.Controllers
{

    [Authorize(Roles = UserRoles.Admin)]
    public class PharmacyController : Controller
    {

        private readonly IPharmacyServices _service;
        public PharmacyController(IPharmacyServices service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Pharmacy/Create
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

        //Get: Pharmacy/Details/id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var pharmacyDetails = await _service.GetByIdAsync(id);

            if (pharmacyDetails == null) return View("NotFound");
            return View(pharmacyDetails);
        }

        //Get: Pharmacy/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var pharmacyDetails = await _service.GetByIdAsync(id);
            if (pharmacyDetails == null) return View("Not Found");
            return View(pharmacyDetails);
        }

        //POST: Pharmacy/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PharmName,PharmAddress,PharmPhone")] Pharmacy pharmacy)
        {
            
            if(id == pharmacy.ID)
            {
                await _service.UpdateAsync(id, pharmacy);
                return RedirectToAction(nameof(Index));
            }
           
                return View(pharmacy);
            

        }

        //Get: Pharmacy/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var pharmacyDetails = await _service.GetByIdAsync(id);
            if (pharmacyDetails == null) return View("Not Found");
            return View(pharmacyDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pharmacyDetails = await _service.GetByIdAsync(id);
            if (pharmacyDetails == null) return View("Not Found");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
