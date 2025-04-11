namespace POSApi.Models.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        // Navigation Properties
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }

}
