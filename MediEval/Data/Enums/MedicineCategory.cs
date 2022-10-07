using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MediEval.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace MediEval.Data.Enums
{
    public enum MedicineCategory
    {
        BabyandToddler = 1,
        PainReliever,
        Diabetic,
        Allergy,
        EyeCare,
        HairCare,
        SkinCare,
        Digestion,
        Vitamins,
        mobilityAid,
        FitnessNutrition

    }
}
