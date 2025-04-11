using System.ComponentModel.DataAnnotations;

namespace POSApi.Models.Entities
{
    public class AddCustomerDTO
    {
        [Required]
        public string? FullName { get; set; }

        public string? Email { get; set; }

    }
}
