using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediEval.Data.Cart;

namespace MediEval.Data.ViewModel
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public double ShoppingCartTotal { get; set; }
    }
}
