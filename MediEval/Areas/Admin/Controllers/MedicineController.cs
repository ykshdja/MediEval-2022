using MediEval.Data.Services;
using MediEval.Data.Static;
using MediEval.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace MediEval.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRoles.Admin)]
    public class MedicineController : Controller
    {

        private readonly IMedicineService _service;
        public MedicineController(IMedicineService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMedicine = await _service.GetAllAsync(n => n.pharmaBrand);
            return View(allMedicine);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var medicineFilter = await _service.GetAllAsync(n => n.pharmaBrand);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = medicineFilter.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", medicineFilter);
        }


        //GET: Medicines/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var medicineDetails = await _service.GetMedicineByIdAsync(id);
            return View(medicineDetails);
        }


        //GET: Medicine/Create
        public async Task<IActionResult> Create()
        {
            var medicineDropdownData = await _service.GetNewMedicineDropdownsValues();
            ViewBag.Pharmacy = new SelectList(medicineDropdownData.Pharmacy, "ID", "PharmName");
            ViewBag.PharmacyBrands = new SelectList(medicineDropdownData.PharmacyBrands, "ID", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(newMedicineViewModel medicine, IFormFile file)
        {

            if (!ModelState.IsValid)
            {
                var medicineDropdownsData = await _service.GetNewMedicineDropdownsValues();
                ViewBag.Pharmacy = new SelectList(medicineDropdownsData.Pharmacy, "ID", "PharmName");
                ViewBag.PharmacyBrands = new SelectList(medicineDropdownsData.PharmacyBrands, "ID", "Name");
                return View(medicine);
            }
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var imgBase64 = stream.ToArray();
            var base64ImgString = Convert.ToBase64String(imgBase64);
            await _service.AddNewMedicineAsync(medicine, base64ImgString);
            return RedirectToAction(nameof(Index));
        }

        //GET: Medicine/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var medicineDetails = await _service.GetMedicineByIdAsync(id);
            if (medicineDetails == null) return View("Not Found");

            var response = new newMedicineViewModel()
            {
                Id = medicineDetails.ID,
                Name = medicineDetails.Name,
                Description = medicineDetails.Description,
                Price = medicineDetails.Price,
                Img = medicineDetails.Img,
                MedicineCategory = medicineDetails.MedicineCategory,
                weight = medicineDetails.weight,
                Quantity = medicineDetails.Quantity,
                InStock = medicineDetails.InStock,
                pharmacyBrandId = medicineDetails.pharmaBrandId,
                pharmacyIds = medicineDetails.pharmacy_medicine.Select(n => n.Pharmacy_ID).ToList(),
            };

            var medicineDropDownData = await _service.GetNewMedicineDropdownsValues();
            ViewBag.Pharmacy = new SelectList(medicineDropDownData.Pharmacy, "ID", "PharmName");
            ViewBag.PharmacyBrands = new SelectList(medicineDropDownData.PharmacyBrands, "ID", "Name");


            return View(response);
        }
        //POST :Medicine/Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, newMedicineViewModel medicine)
        {
            if (id != medicine.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var medicineDropdownsData = await _service.GetNewMedicineDropdownsValues();

                ViewBag.Pharmacy = new SelectList(medicineDropdownsData.Pharmacy, "ID", "PharmName");
                ViewBag.PharmacyBrands = new SelectList(medicineDropdownsData.PharmacyBrands, "ID", "Name");


                return View(medicine);
            }

            await _service.UpdateMedicineAsync(medicine);
            return RedirectToAction(nameof(Index));
        }


    }
}
