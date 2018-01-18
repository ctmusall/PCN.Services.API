using System;
using System.IO;
using System.Net.Mail;

namespace Email.API.Interfaces
{
    public interface IEmailAttachmentSeeker
    {
        Attachment RetrieveAttachmentFromDocumentUrl(string documentUrl);
        Attachment RetrieveAttachmentFromDocRepoId(Guid docRepoId);
        Attachment RetrieveAttachmentFromByteArray(byte[] documentBytes);
        Attachment RetrieveAttachmentFromStream(Stream documentStream);
    }
}
