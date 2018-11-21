using System;
using System.Collections.Generic;
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
                FirstName = "Jens",
                LastName = "Madsen"
            }).Entity;

            var owner2 = ctx.Owners.Add(new Owner
            {
                FirstName = "Bob",
                LastName = "Wild"
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

            // Create two users with hashed and salted passwords
            string password = "b";
            byte[] passwordHashA, passwordSaltA, passwordHashAA, passwordSaltAA;
            CreatePasswordHash(password, out passwordHashA, out passwordSaltA);
            CreatePasswordHash(password, out passwordHashAA, out passwordSaltAA);

            List<User> users = new List<User>
            {
                new User {
                    Username = "a",
                    PasswordHash = passwordHashA,
                    PasswordSalt = passwordSaltA,
                    IsAdmin = false
                },
                new User {
                    Username = "aa",
                    PasswordHash = passwordHashAA,
                    PasswordSalt = passwordSaltAA,
                    IsAdmin = true
                }
            };

            ctx.Users.AddRange(users);
            ctx.SaveChanges();
        }

        // This method computes a hashed and salted password using the HMACSHA512 algorithm.
        // The HMACSHA512 class computes a Hash-based Message Authentication Code (HMAC) using
        // the SHA512 hash function. When instantiated with the parameterless constructor (as
        // here) a randomly Key is generated. This key is used as a password salt.

        // The computation is performed as shown below:
        //   passwordHash = SHA512(password + Key)

        // A password salt randomizes the password hash so that two identical passwords will
        // have significantly different hash values. This protects against sophisticated attempts
        // to guess passwords, such as a rainbow table attack.
        // The password hash is 512 bits (=64 bytes) long.
        // The password salt is 1024 bits (=128 bytes) long.
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}