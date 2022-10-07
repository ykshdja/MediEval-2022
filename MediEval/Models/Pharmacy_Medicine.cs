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
    public class Pharmacy_Medicine
    {
        public int Pharmacy_ID { get; set; }
        public Pharmacy pharmacy { get; set; }

        public int Medicine_ID { get; set; }
        public Medicine medicine { get; set; } //Actor
    }
}
