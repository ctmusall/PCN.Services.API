using System.ComponentModel.DataAnnotations;

namespace Phone.API.Models
{
    public class PhoneContactRequest
    {
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
