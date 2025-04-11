using System.ComponentModel.DataAnnotations;

namespace POSApi.Models.Entities
{
  


    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }

}
