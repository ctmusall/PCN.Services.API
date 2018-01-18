using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Email.API.Models
{
    public class EmailAttachmentRequest
    {
        [Required]
        public string DocumentName { get; set; }

        public Guid DocRepoId { get; set; }

        public string DocumentUrl { get; set; }

        public byte[] DocumentByteArray { get; set; }

        public Stream DocumentStream { get; set; }
    }
}