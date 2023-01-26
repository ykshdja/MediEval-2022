using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Providers.Entities;

namespace MediEval.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        [NotMapped]
        public IList<string> RoleNames { get; set; }

        public static implicit operator User(ApplicationUser v)
        {
            throw new NotImplementedException();
        }
    }
}
