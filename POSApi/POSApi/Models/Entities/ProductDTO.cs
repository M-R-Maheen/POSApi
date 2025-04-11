using System.ComponentModel.DataAnnotations;

namespace POSApi.Models.Entities
{
    public class ProductDTO
    {
        [Required]
        public string? ProductName { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

    }
}
