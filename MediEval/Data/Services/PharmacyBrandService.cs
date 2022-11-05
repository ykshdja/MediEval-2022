
using MediEval.Data.Base;
using MediEval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MediEval.Data.Services
{
    public class PharmacyBrandService : EntityBaseRepository<PharmacyBrand>, IPharmacyBrandService
    {
        public PharmacyBrandService(AppDbContext context) : base(context)
        {
        }
    }

   
}
