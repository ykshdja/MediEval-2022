﻿using System.ComponentModel.DataAnnotations;

namespace MediEval.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Medicine Medicine { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
