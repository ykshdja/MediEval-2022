using MediEval.Models;

namespace MediEval.Data.Services
{
    public interface IPharmacyServices
    {

        Task<IEnumerable<Pharmacy>> GetAllAsync();
        Task<Pharmacy> GetByIdAsync(int id);
        Task AddAsync(Pharmacy pharmacy);
        Task<Pharmacy> UpdateAsync(int id, Pharmacy pharmacy);
        Task DeleteAsync(int id);

    }
}
