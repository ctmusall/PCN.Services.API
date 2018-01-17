using System.ComponentModel.DataAnnotations;

namespace Email.API.Models
{
    public class EmailContactRequest
    {
        [Required]
        public string EmailAddress { get; set; }

        public string DisplayName { get; set; }
    }
}
