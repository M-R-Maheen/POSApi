using System.ComponentModel.DataAnnotations;

namespace POSApi.Models.Entities
{
   
    public class Customer
    {
        public Guid Id { get; set; }

        [Required]
        public string? FullName { get; set; }

        public string? Email { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }

}
