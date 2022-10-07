using MediEval.Models;
using Microsoft.EntityFrameworkCore;

namespace MediEval.Data.Services
{

    public class PharmacyService : IPharmacyServices
    {
        private readonly AppDbContext _context;
        public PharmacyService( AppDbContext context)
        {
            _context = context;              
        }
        public void Add(Pharmacy pharmacy)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pharmacy>> GetAll()
        {
            var result = await _context.Pharmacies.ToListAsync();
            return result;
        }

        public Pharmacy GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Pharmacy pharmacy)
        {
            throw new NotImplementedException();
        }
    }
}
