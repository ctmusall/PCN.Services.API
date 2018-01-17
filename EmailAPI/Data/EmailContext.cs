using Email.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Email.API.Data
{
    public class EmailContext : DbContext
    {
        public EmailContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<EmailLog> LoggedEmails { get; set; }
        public DbSet<EmailContact> EmailContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailLog>().ToTable("EmailLog");
            modelBuilder.Entity<EmailContact>().ToTable("EmailContact")
                .HasOne(e => e.EmailLog)
                .WithMany(b => b.EmailContacts)
                .HasForeignKey(e => e.EmailLogId);
        }
    }
}
