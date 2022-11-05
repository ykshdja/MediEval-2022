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
using MediEval.Data.Base;
using System.Diagnostics.CodeAnalysis;

namespace MediEval.Models
{
    public class Medicine : IEntityBase
    {
        [Key]
        [Required]
        public int ID { get; set; } //medID
        [Required]
        public String Name { get; set; }
        [Required]
        public String Description { get; set; } 
        [Required]
        public int Quantity { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public bool InStock { get; set; }
        [Required]
        public string weight { get; set; }
        [AllowNull]
        public String? Img { get; set; }

        public MedicineCategory MedicineCategory { get; set; }

        //Relationship
        public List<Pharmacy_Medicine> pharmacy_medicine { get; set; }


        [ForeignKey("pharmaBrandId")]
        public int pharmaBrandId { get; set; }
        public PharmacyBrand pharmaBrand { get; set; }

    }
}
