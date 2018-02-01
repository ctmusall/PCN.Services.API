using Microsoft.EntityFrameworkCore;
using Phone.API.Models;

namespace Phone.API.Data
{
    public class PhoneContext : DbContext 
    {
        public PhoneContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<PhoneLog> PhoneLogs { get; set; }
        public DbSet<PhoneContact> PhoneContacts { get; set; }
        public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneLog>().ToTable("PhoneLog");
            modelBuilder.Entity<PhoneContact>().ToTable("PhoneContact")
                .HasOne(p => p.PhoneLog)
                .WithMany(c => c.PhoneContacts)
                .HasForeignKey(e => e.PhoneLogId);
            modelBuilder.Entity<Application>().ToTable("Application");
        }
    }
}