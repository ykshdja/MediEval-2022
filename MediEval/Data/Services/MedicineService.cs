using MediEval.Models;
using MediEval.Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediEval.Data.ViewModel;

namespace MediEval.Data.Services
{
    public class MedicineService : EntityBaseRepository<Medicine>, IMedicineService
    {

        private readonly AppDbContext _context;
        public MedicineService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMedicineAsync(newMedicineViewModel data, string base64Img)
        {
            var newMedicine = new Medicine()
            {
                Name = data.Name,
                Description = data.Description,
                Quantity = data.Quantity,
                Price = data.Price,
                InStock = data.InStock,
                weight = data.weight,
                MedicineCategory = data.MedicineCategory,
                pharmaBrandId = data.pharmacyBrandId,
                Img = base64Img
            };
            await _context.Medicines.AddAsync(newMedicine);
            await _context.SaveChangesAsync();

            //Add Medicine Pharmacy
            foreach(var pharmacyId in data.pharmacyIds)
            {
                var newPharmacyMedicine = new Pharmacy_Medicine()
                {
                    Medicine_ID = newMedicine.ID,
                    Pharmacy_ID = pharmacyId
                };
                await _context.Pharmacy_Medicines.AddAsync(newPharmacyMedicine);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Medicine> GetMedicineByIdAsync(int id)
        {

            var medicineDetail = await _context.Medicines
                .Include(c => c.pharmaBrand)
                .Include(am => am.pharmacy_medicine).ThenInclude(a => a.pharmacy)
                .FirstOrDefaultAsync(n => n.ID == id);

            return medicineDetail;
        }

        public async Task<NewMedicineDropdownViewModel> GetNewMedicineDropdownsValues()
        {
            var response = new NewMedicineDropdownViewModel()
            {
                Pharmacy = await _context.Pharmacies.OrderBy(n => n.PharmName).ToListAsync(),
                PharmacyBrands = await _context.PharmaBrands.OrderBy(n=>n.Name).ToListAsync()
               
            };

            return response;
        }

        public async Task UpdateMedicineAsync(newMedicineViewModel data)
        {
            var dbMedicine = await _context.Medicines.FirstOrDefaultAsync(n => n.ID == data.Id);

            if (dbMedicine != null)
            {
                dbMedicine.Name = data.Name;
                dbMedicine.Description = data.Description;
                dbMedicine.Price = data.Price;
                dbMedicine.Img = data.Img;
                dbMedicine.InStock = data.InStock;
                dbMedicine.pharmaBrandId = data.pharmacyBrandId;
                dbMedicine.weight = data.weight;
                dbMedicine.MedicineCategory = data.MedicineCategory;
                dbMedicine.Quantity = data.Quantity;
                await _context.SaveChangesAsync();
            }

            //Remove existing Pharmacy
            var existingMedicinedb = _context.Pharmacy_Medicines.Where(n => n.Medicine_ID == data.Id).ToList();
            _context.Pharmacy_Medicines.RemoveRange(existingMedicinedb);
            await _context.SaveChangesAsync();

            //Add Pharmacy for the Medicine 
            foreach (var PharmacyId in data.pharmacyIds)
            {
                var newMedicinePharmacy = new Pharmacy_Medicine()
                {
                    Medicine_ID = data.Id,
                    Pharmacy_ID = PharmacyId
                };
                await _context.Pharmacy_Medicines.AddAsync(newMedicinePharmacy);
            }
            await _context.SaveChangesAsync();
        }







    }
}
