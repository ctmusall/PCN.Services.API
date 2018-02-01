using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Phone.API.Models
{
    public class PhoneMessageRequest
    {
        [Required]
        public ICollection<PhoneContactRequest> PhoneContacts { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
