using HospitalApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace HospitalApi.Persistence
{
    public class HospitalContext : DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
        {}

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Condition> Conditions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(e =>
            {
                e.HasKey(p => p.Id);

                e.Property(p => p.Name)
                .IsRequired(false);

                e.Property(p => p.Age)
                .IsRequired(false);
            });

            modelBuilder.Entity<Condition>(e =>
            {
                e.HasKey(p => p.IdCondition);

                e.Property(p => p.ColorOfUrgency)
                .IsRequired(false);
            });
        }
    }
}
