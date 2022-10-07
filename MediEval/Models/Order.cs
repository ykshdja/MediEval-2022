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
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int? PrescriptionId { get; set; } 
        public int MedicineId { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public double OrderCost { get; set; }
    }
}
