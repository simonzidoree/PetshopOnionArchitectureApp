using Microsoft.EntityFrameworkCore;
using Petshop.Core.Entities;

namespace Petshop.Infrastructure.Data
{
    public class PetshopContext : DbContext
    {
        public PetshopContext(DbContextOptions<PetshopContext> opt) : base(opt)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Owner)
                .WithMany(p => p.Pets)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}