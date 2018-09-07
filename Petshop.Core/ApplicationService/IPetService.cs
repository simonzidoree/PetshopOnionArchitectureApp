using System;
using System.Collections.Generic;
using Petshop.Core.Entities;

namespace Petshop.Core.ApplicationService
{
    public interface IPetService
    {
        //New Pet
        Pet NewPet(string name,
            string type,
            DateTime birthDate,
            DateTime soldDate,
            string color,
            string previousOwner,
            double price);

        //Create
        Pet CreatePet(Pet pet);

        //Read
        Pet FindPetById(int id);

        List<Pet> GetAllPets();

        List<Pet> GetFiveCheapestPets();

        List<Pet> GetSortedByHighestPricePets();

        List<Pet> GetSortedByLowestPricePets();

        List<Pet> GetAllByType(string petType);

        //Update
        Pet UpdatePet(int id, Pet petUpdate);

        //Delete
        Pet DeletePet(int id);
    }
}