using Petshop.Core.DomainService;
using Petshop.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Petshop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public Pet Create(Pet pet)
        {
            pet.ID = FakeDB.PetID++;
            var pets = FakeDB.Pets.ToList();
            pets.Add(pet);
            FakeDB.Pets = pets;
            return pet;
        }

        public IEnumerable<Pet> ReadAllPets()
        {
            return FakeDB.Pets;
        }

        public Pet ReadByID(int id)
        {
            foreach (var pet in FakeDB.Pets.ToList())
            {
                if (pet.ID == id)
                {
                    return pet;
                }
            }
            return null;
        }

        public Pet Update(Pet petUpdate)
        {
            var petFromDB = this.ReadByID(petUpdate.ID);
            if (petFromDB != null)
            {
                petFromDB.Name = petUpdate.Name;
                petFromDB.Type = petUpdate.Type;
                petFromDB.Birthdate = petUpdate.Birthdate;
                petFromDB.SoldDate = petUpdate.SoldDate;
                petFromDB.Color = petUpdate.Color;
                petFromDB.PreviousOwner = petUpdate.PreviousOwner;
                petFromDB.Price = petUpdate.Price;
                return petFromDB;
            }
            return null;
        }

        public Pet Delete(int id)
        {
            var pets = FakeDB.Pets.ToList();
            var petFoundId = this.ReadByID(id);

            if (petFoundId != null)
            {
                pets.Remove(petFoundId);
                FakeDB.Pets = pets;
                return petFoundId;
            }
            return null;
        }
    }
}
