using MediEval.Models;
using Microsoft.AspNetCore.Identity;

namespace MediEval.Areas.Admin.Models
{
    public class UserViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
