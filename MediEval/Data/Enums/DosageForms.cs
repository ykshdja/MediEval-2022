
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
    public class DosageForms
    {
        public enum DosageForm
        {
            Oral,
            Topical,
            Injection
            
        }
        public enum Oral
        {
            Tablet,
            Capsules,
            Pills,
            Troches,
            Pellets,

        }
        public enum Topical
        {
            liniments,
            Lotions,
            Ointments,
            Pastes,
            Sprays,

        }
        public enum Injection
        {
            Emulsions,
            Gel,
            Magma
        }
    }
}
