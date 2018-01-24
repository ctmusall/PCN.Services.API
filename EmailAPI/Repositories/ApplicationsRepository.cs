using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Email.API.Data;
using Email.API.Interfaces;
using Email.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.API.Repositories
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly EmailContext _context;

        public ApplicationsRepository(EmailContext context)
        {
            _context = context;
        }

        public async Task<List<Application>> RetrieveAllApplications()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application> RetrieveApplicationById(Guid id)
        {
            return await _context.Applications.FirstOrDefaultAsync(app => app.Id == id);
        }

        public async Task<Application> RetrieveApplicationByName(string name)
        {
            return await _context.Applications.FirstOrDefaultAsync(app => string.Equals(app.Name, name));
        }

        public Task<int> AddApplication(string applicationName)
        {
            _context.Applications.Add(new Application {Name = applicationName});

            return _context.SaveChangesAsync();
        }

        public Task<int> UpdateApplication(Application application)
        {
            _context.Entry(application).State = EntityState.Modified;

            return _context.SaveChangesAsync();
        }

        public async Task<int> DeleteApplication(Guid id)
        {
            var applicationToDelete = await _context.Applications.FirstOrDefaultAsync(app => app.Id == id);

            if (applicationToDelete == null) return 0;

            _context.Applications.Remove(applicationToDelete);

            return await _context.SaveChangesAsync();
        }

        public async Task<bool> ApplicationExists(Guid id)
        {
            return await _context.Applications.AnyAsync(app => app.Id == id);
        }

        public async Task<bool> ApplicationExists(string name)
        {
            return await _context.Applications.AnyAsync(app => string.Equals(app.Name, name));
        }
    }
}
