using System;
using System.IO;

namespace Email.API.Models
{
    public class EmailAttachmentRequest
    {
        public string DocumentUrl { get; set; }

        public Guid DocRepoId { get; set; }

        public byte[] DocumentByteArray { get; set; }

        public Stream DocumentStream { get; set; }
    }
}