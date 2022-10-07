using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace MediEval.Models
{
    public class Pharmacy
    {
        [Key]
        public int PharmID { get; set; }
        [Required]
        [Display(Name = "Pharmacy")]
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 50 chars")]
        public String PharmName { get; set; }
        [Required]
        [Display(Name = "Address")]
        public String PharmAddress { get; set; }
        [Display(Name = "Phone Number")]
        public String PharmPhone { get; set; }
        // public String Time_at { get; set; }
        //Relationships 
        public List<Pharmacy_Medicine> pharmacy_medicine { get; set; }

    }
}
