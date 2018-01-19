using System;
using System.Net.Mail;

namespace Email.API.Interfaces
{
    public interface IEmailAttachmentSeeker
    {
        Attachment RetrieveAttachmentFromDocumentUrl(string documentUrl, string documentName);
        Attachment RetrieveAttachmentFromDocRepoId(Guid docRepoId);
        Attachment RetrieveAttachmentFromByteArray(byte[] documentBytes);
        Attachment RetrieveAttachmentFromNetworkPath(string networkPath, string documentName);
    }
}
