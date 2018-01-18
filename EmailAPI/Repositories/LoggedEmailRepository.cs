using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Email.API.Data;
using Email.API.Interfaces;
using Email.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.API.Repositories
{
    public class LoggedEmailRepository : ILoggedEmailRepository
    {
        private readonly EmailContext _context;
        private readonly IEmailRequestUtility _requestUtility;

        public LoggedEmailRepository(EmailContext context, IEmailRequestUtility requestUtility)
        {
            _context = context;
            _requestUtility = requestUtility;
        }

        public async Task<List<EmailLog>> RetrieveAllLoggedEmails()
        {
            return await _context.LoggedEmails.Include(contact => contact.EmailContacts).ToListAsync();
        }

        public async Task<EmailLog> RetrieveLoggedEmailById(Guid id)
        {
            return await _context.LoggedEmails.Include(contact => contact.EmailContacts).FirstOrDefaultAsync(email => email.Id == id);
        }

        public int LogEmail(EmailRequest emailRequest)
        {
            var loggedEmail = _requestUtility.ConvertRequestEmailToLoggedEmail(emailRequest);
            _context.Add(loggedEmail);

            var emailContacts = _requestUtility.ConvertEmailContactRequestsToEmailContacts(emailRequest, loggedEmail);
            _context.AddRange(emailContacts);

            return _context.SaveChanges();
        }

        public async Task<int> DeleteEmailFromLog(Guid id)
        {
            var emailToDelete = await _context.LoggedEmails.Include(contact => contact.EmailContacts).FirstOrDefaultAsync(email => email.Id == id);

            if (emailToDelete == null) return 0;

            _context.LoggedEmails.Remove(emailToDelete);

            var emailContacts = await _context.EmailContacts.Where(contact => contact.EmailLogId == id).ToListAsync();

            _context.EmailContacts.RemoveRange(emailContacts);

            return await _context.SaveChangesAsync();
        }
    }
}
