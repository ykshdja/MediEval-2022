using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MediEval.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediEval.Models
{
    public class Medicine
    {
        [Key]
        public int MedicineID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; } 
        [Required]
        public int Quantity { get; set; }
        [Required]
        public String Price { get; set; }
        [Required]
        public bool InStock { get; set; }
        [Required]
        public string weight { get; set; }
        
        public String Img { get; set; }

        public MedicineCategory MedicineCategory { get; set; }
        public List<Pharmacy_Medicine> pharmacy_medicine { get; set; }
        public int pharmaBrandId { get; set; }
        [ForeignKey("pharmaBrandId")]
        public PharmacyBrand pharmaBrand { get; set; }


    }
}
