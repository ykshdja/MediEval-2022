using MediEval.Models;
using Microsoft.AspNetCore.Identity;

namespace MediEval.Data.ViewModel
{
    public class AdminViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
