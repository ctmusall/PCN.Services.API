using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Email.API.Interfaces;
using MimeTypes;

namespace Email.API.Email
{
    public class EmailAttachmentSeeker : IEmailAttachmentSeeker
    {
        public Attachment RetrieveAttachmentFromDocumentUrl(string documentUrl, string documentName)
        {
            using (var client = new WebClient())
            {
                var content = client.DownloadData(documentUrl);
                var stream = new MemoryStream(content);
                var contentType = new ContentType(client.ResponseHeaders["Content-Type"]);
                var extension = MimeTypeMap.GetExtension(contentType.MediaType);

                return new Attachment(stream, new ContentType(client.ResponseHeaders["Content-Type"]){ Name = $"{documentName}{extension}"});
            }
        }

        public Attachment RetrieveAttachmentFromDocRepoId(Guid docRepoId)
        {
            return null;
        }

        public Attachment RetrieveAttachmentFromBase64(string documentString, string documentName, string mimeType)
        {
            var data = Convert.FromBase64String(documentString);
            var fileExtension = MimeTypeMap.GetExtension(mimeType);
            return new Attachment(new MemoryStream(data), new ContentType {Name = $"{documentName}{fileExtension}", MediaType = mimeType});
        }

        public Attachment RetrieveAttachmentFromNetworkPath(string networkPath, string documentName)
        {
            var fileStream = File.OpenRead(networkPath);
            var fileExtension = Path.GetExtension(networkPath);
            var mimeType = MimeTypeMap.GetMimeType(fileExtension);
            return new Attachment(fileStream, new ContentType{ Name = $"{documentName}{fileExtension}", MediaType = mimeType});
        }
    }
}
