using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MediEval.Models
{
    public class PharmacyBrand
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Neo sporin")]
        public string Name { get; set; }

        [Display(Name = "Pain reliever")]
        public string? Description { get; set; }

        
    }
}
