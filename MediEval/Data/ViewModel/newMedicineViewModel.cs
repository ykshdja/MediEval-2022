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
    public class newMedicineViewModel
    {

        public int Id { get; set; }

        [Display(Name = "Medicine name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Medicine description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Size")]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

      
        [Display(Name = "Availability")]
        [Required(ErrorMessage = "Availability Status is required")]
        public bool InStock { get; set; }
        

        [Display(Name = "Weight (With Unit of Measurement)")]
        [Required(ErrorMessage = "Weight Information is required")]
        public string weight { get; set; }

        [Display(Name = "Medicine Image")]
        //[Required(ErrorMessage = "Medicine Image URL is required")]
        [AllowNull]
        public String? Img { get; set; }

        [Display(Name = "Select a Drug Class")]
        [Required(ErrorMessage = "Medicine category is required")]
        public MedicineCategory MedicineCategory { get; set; }


        [Display(Name = "Select Manufacturer(s)")]
        [Required(ErrorMessage = "Manufacturer(s) Information is required")]
        public int pharmacyBrandId { get; set; }


        [Display(Name = "Select Pharmacy(s)")]
        [Required(ErrorMessage = "Pharmacy(s) is required")]
        public List<int> pharmacyIds { get; set; }

   

    }
}
