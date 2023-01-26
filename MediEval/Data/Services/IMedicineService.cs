using MediEval.Data.Base;
using MediEval.Data.ViewModel;
using MediEval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace MediEval.Data.Services
{
    public interface IMedicineService: IEntityBaseRepository<Medicine>
    {
        Task<Medicine> GetMedicineByIdAsync(int id);
        Task<NewMedicineDropdownViewModel> GetNewMedicineDropdownsValues();
        Task AddNewMedicineAsync(newMedicineViewModel data, string base64Img);
        Task UpdateMedicineAsync(newMedicineViewModel data);
    }
}
