using System;
using System.Collections.Generic;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entities;

namespace Petshop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet NewPet(string name, string type, DateTime birthDate, DateTime soldDate, string color, string previousOwner, double price)
        {
            var pet = new Pet()
            {
                Name = name,
                Type = type,
                Birthdate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };

            return pet;
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.Create(pet);
        }

        public Pet FindPetById(int id)
        {
            return _petRepository.ReadByID(id);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.ReadAllPets().ToList();
        }

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.ID);
            pet.Name = petUpdate.Name;
            pet.Type = petUpdate.Type;
            pet.Birthdate = petUpdate.Birthdate;
            pet.SoldDate = petUpdate.SoldDate;
            pet.Color = petUpdate.Color;
            pet.PreviousOwner = petUpdate.PreviousOwner;
            pet.Price = petUpdate.Price;
            return pet;
        }

        public Pet DeletePet(int id)
        {
            return _petRepository.Delete(id);
        }

        public List<Pet> GetFiveCheapestPets()
        {
            return _petRepository.ReadAllPets()
                .OrderBy(pet => pet.Price).Take(5)
                .ToList();
        }

        public List<Pet> GetAllByType(string petType)
        {
            var list = _petRepository.ReadAllPets();
            var query = list.Where(pet => pet.Type.Equals(petType)).OrderBy(pet => pet.Type);
            return query.ToList();
        }

        public List<Pet> GetSortedByHighestPricePets()
        {
            return _petRepository.ReadAllPets()
                .OrderByDescending(pet => pet.Price)
                .ToList();
        }

        public List<Pet> GetSortedByLowestPricePets()
        {
            return _petRepository.ReadAllPets()
                .OrderBy(pet => pet.Price)
                .ToList();
        }
    }
}
