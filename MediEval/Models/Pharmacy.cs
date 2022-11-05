using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using MediEval.Data.Base;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace MediEval.Models
{
    public class Pharmacy :IEntityBase
    {
        [Key]
       public int ID { get; set; } //PharmID

        [Display(Name = "Pharmacy")]
        [Required(ErrorMessage = "Pharmacy Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Pharmacy Name must be between 3 and 50 chars")]
    
        public String PharmName { get; set; }
        [Required(ErrorMessage = "Pharmacy Address is required")]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Pharmacy Name must be between 3 and 50 chars")]
       
        public String PharmAddress { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        
        public String PharmPhone { get; set; }

        //Relationships
        [AllowNull]
        public List<Pharmacy_Medicine>? pharmacy_medicine { get; set; } = new List<Pharmacy_Medicine>();
    }
}
