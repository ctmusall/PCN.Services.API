using System;
using System.ComponentModel.DataAnnotations;

namespace Email.API.Models
{
    public class EmailAttachmentRequest
    {
        [Required]
        public string DocumentName { get; set; }

        public string DocumentUrl { get; set; }

        public Guid DocRepoId { get; set; }

        public string DocumentBase64 { get; set; }
        public string DocumentMimeType { get; set; }

        public string DocumentNetworkPath { get; set; }
    }
}