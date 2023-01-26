using Microsoft.AspNetCore.WebUtilities;


namespace MediEval.Data.Services
{
    public interface IBufferedFileUploadService
    {
        Task<bool> UploadFile(IFormFile file);


    }
}
