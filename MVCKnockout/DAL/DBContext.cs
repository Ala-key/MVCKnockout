using Microsoft.EntityFrameworkCore;
using MVCKnockout.Models;

namespace MVCKnockout.DAL
{
    public class PeopleDbContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }

        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the People entity here
            modelBuilder.Entity<People>()
                .HasKey(p => p.id); // Define the primary key

            modelBuilder.Entity<People>()
                .Property(p => p.Email)
                .IsRequired(); // Email should be a required field

            modelBuilder.Entity<People>()
                .Property(p => p.Password)
                .IsRequired(); // Password should be a required field

            // You can add more configuration options or relationships here if needed

            base.OnModelCreating(modelBuilder);
        }
    }
}
