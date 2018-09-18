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
    }
}