using Email.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.API.Data
{
    public class EmailContext : DbContext
    {
        public EmailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LoggedEmail> LoggedEmails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LoggedEmail>().ToTable("LoggedEmail");
        }
    }
}
