using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phone.API.Models
{
    public class PhoneLog
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Message { get; set; }
        public DateTime DateTimeSent { get; set; }
        public ICollection<PhoneContact> PhoneContacts { get; set; }
    }
}
