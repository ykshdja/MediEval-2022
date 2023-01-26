using MediEval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MediEval.Data.ViewModel
{
    public class NewMedicineDropdownViewModel
    {
        public NewMedicineDropdownViewModel()
        {
            Pharmacy = new List<Pharmacy>();
            PharmacyBrands = new List<PharmacyBrand>();
        }

        public List<Pharmacy> Pharmacy { get; set; }
        public List<PharmacyBrand> PharmacyBrands { get; set; }
        
    }
}
