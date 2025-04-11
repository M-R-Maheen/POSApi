using System.ComponentModel.DataAnnotations;

namespace POSApi.Models.Entities
{
    public class UpdateCustomerDTO
    {
        [Required]
        public string? FullName { get; set; }
    }
}
