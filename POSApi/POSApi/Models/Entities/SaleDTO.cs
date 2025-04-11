using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POSApi.Models.Entities
{
    
    public class SaleDTO
    {
        public int ProductId { get; set; }
        public Guid CustomerId { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }

}
