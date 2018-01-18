using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Email.API.Interfaces;

namespace Email.API.Email
{
    public class EmailAttachmentSeeker : IEmailAttachmentSeeker
    {
        public Attachment RetrieveAttachmentFromDocumentUrl(string documentUrl)
        {
            using (var client = new WebClient())
            {
                var content = client.DownloadData(documentUrl);
                var stream = new MemoryStream(content);
                
                return new Attachment(stream, new ContentType(client.ResponseHeaders["Content-Type"]));
            }
        }

        public Attachment RetrieveAttachmentFromDocRepoId(Guid docRepoId)
        {
            return null;
        }

        public Attachment RetrieveAttachmentFromByteArray(byte[] documentBytes)
        {
            return null;
        }

        public Attachment RetrieveAttachmentFromStream(Stream documentStream)
        {
            return null;
        }
    }
}
