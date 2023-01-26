using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediEval.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }
        public double Price { get; set; }
        [ForeignKey("MedicineId")]
        public int MedicineId { get; set; }
       
        public Medicine medicine { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
      
        public Order order { get; set; }
    }
}
