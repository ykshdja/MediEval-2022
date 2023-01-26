using System;
using System.ComponentModel.DataAnnotations;

namespace MediEval.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
