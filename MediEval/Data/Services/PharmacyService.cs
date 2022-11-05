using MediEval.Data.Base;
using MediEval.Models;
using Microsoft.EntityFrameworkCore;

namespace MediEval.Data.Services
{

    public class PharmacyService : EntityBaseRepository<Pharmacy>, IPharmacyServices
    {
        public PharmacyService(AppDbContext context) : base(context) { }

       
    }
}
