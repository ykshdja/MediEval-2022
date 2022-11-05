using MediEval.Data.Base;
using MediEval.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MediEval.Models
{
    public class PharmacyBrand :IEntityBase
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [Display(Name = "Name")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Dosage Form is Required")]
        [Display(Name = "Dosage Form")]
        public string? DosageForm { get; set; }


        [Display(Name = "NDC Code")]
        [Required(ErrorMessage = "NDC Code is Required")]
        public string NDC_Code { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        [Display(Name = "Category")]

        public MedicineCategory category { get; set; }
        

        //Relationship
        public List<Medicine> medicines { get; set; }

    }
}
