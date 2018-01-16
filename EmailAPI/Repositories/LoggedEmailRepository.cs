using System;
using System.Collections.Generic;
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

        public LoggedEmailRepository(EmailContext context)
        {
            _context = context;
        }

        public async Task<List<LoggedEmail>> RetrieveAllLoggedEmails()
        {
            return await _context.LoggedEmails.ToListAsync();
        }

        public async Task<LoggedEmail> RetrieveLoggedEmailById(Guid id)
        {
            return await _context.LoggedEmails.FirstOrDefaultAsync(email => email.Id == id);
        }

        public async Task<int> CreateLoggedEmail(LoggedEmail loggedEmail)
        {
            _context.Add(loggedEmail);
            return await _context.SaveChangesAsync();
        }
    }
}
