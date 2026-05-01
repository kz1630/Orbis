using Microsoft.EntityFrameworkCore;

namespace Orbis.Models
{
    public class OrbisDbContext : DbContext
    {
        public OrbisDbContext(DbContextOptions<OrbisDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<InsuranceService> InsuranceServices { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Person)
                .WithMany(p => p.Contracts)
                .HasForeignKey(c => c.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.InsuranceService)
                .WithMany(s => s.Contracts)
                .HasForeignKey(c => c.InsuranceServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.CreatedByUser)
                .WithMany()
                .HasForeignKey(c => c.CreatedByUserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
