using System;
using Petshop.Core.Entities;

namespace Petshop.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetshopContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var owner1 = ctx.Owners.Add(new Owner
            {
                Name = "Jens Madsen"
            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner
            {
                Name = "Bob Wild"
            }).Entity;

            ctx.Pets.Add(new Pet
            {
                Name = "Bob",
                Type = "Cat",
                Birthdate = new DateTime(2010, 05, 10),
                SoldDate = new DateTime(2017, 10, 10),
                Color = "White",
                PreviousOwner = "John Doe",
                Price = 749.99,
                Owner = owner1
            });

            ctx.Pets.Add(new Pet
            {
                Name = "Karla",
                Type = "Tiger",
                Birthdate = new DateTime(2012, 06, 17),
                SoldDate = new DateTime(2013, 08, 11),
                Color = "White",
                PreviousOwner = "Amanda Madsen",
                Price = 2500.00,
                Owner = owner1
            });

            ctx.Pets.Add(new Pet
            {
                Name = "Mikkel",
                Type = "Dog",
                Birthdate = new DateTime(2005, 01, 04),
                SoldDate = new DateTime(2018, 01, 05),
                Color = "Brown",
                PreviousOwner = "Camilla Jensen",
                Price = 1249.99,
                Owner = owner2
            });
            ctx.SaveChanges();
        }
    }
}