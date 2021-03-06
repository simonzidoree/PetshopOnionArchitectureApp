﻿using System;
using System.Collections.Generic;
using Petshop.Core.Entities;

namespace Petshop.Infrastructure.Data
{
    public static class FakeDB
    {
        public static int PetID = 1;
        public static int OwnerID = 1;

        public static IEnumerable<Pet> Pets;
        public static IEnumerable<Owner> Owners;

        public static void InitData()
        {
            var pet1 = new Pet
            {
                ID = PetID++,
                Name = "Bob",
                Type = "Cat",
                Birthdate = new DateTime(2010, 05, 10),
                SoldDate = new DateTime(2017, 10, 10),
                Color = "White",
                PreviousOwner = "John Doe",
                Price = 749.99,
                Owner = new Owner {ID = 1}
            };
            var pet2 = new Pet
            {
                ID = PetID++,
                Name = "Jens",
                Type = "Fish",
                Birthdate = new DateTime(2013, 07, 12),
                SoldDate = new DateTime(2015, 12, 20),
                Color = "Orange",
                PreviousOwner = "Bo Emil",
                Price = 199.99,
                Owner = new Owner {ID = 1}
            };
            var pet3 = new Pet
            {
                ID = PetID++,
                Name = "Mikkel",
                Type = "Dog",
                Birthdate = new DateTime(2005, 01, 04),
                SoldDate = new DateTime(2018, 01, 05),
                Color = "Brown",
                PreviousOwner = "Camilla Jensen",
                Price = 1249.99,
                Owner = new Owner {ID = 1}
            };
            var pet4 = new Pet
            {
                ID = PetID++,
                Name = "Per",
                Type = "Goat",
                Birthdate = new DateTime(2011, 11, 02),
                SoldDate = new DateTime(2016, 09, 25),
                Color = "White",
                PreviousOwner = "Gert Nielsen",
                Price = 329.99,
                Owner = new Owner {ID = 2}
            };
            var pet5 = new Pet
            {
                ID = PetID++,
                Name = "Karla",
                Type = "Tiger",
                Birthdate = new DateTime(2012, 06, 17),
                SoldDate = new DateTime(2013, 08, 11),
                Color = "White",
                PreviousOwner = "Amanda Madsen",
                Price = 2500.00,
                Owner = new Owner {ID = 2}
            };

            Pets = new List<Pet> {pet1, pet2, pet3, pet4, pet5};

            var owner1 = new Owner
            {
                ID = OwnerID++,
                FirstName = "Bob",
                LastName = "Wild"
            };
            var owner2 = new Owner
            {
                ID = OwnerID++,
                FirstName = "Jens",
                LastName = "Madsen"
            };

            Owners = new List<Owner> {owner1, owner2};
        }
    }
}