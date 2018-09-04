using System.Collections.Generic;
using Petshop.Core.Entities;

namespace Petshop.Core.DomainService
{
    public interface IPetRepository
    {
        //Create Data
        Pet Create(Pet pet);

        //Read Data
        Pet ReadByID(int id);
        IEnumerable<Pet> ReadAllPets();

        //Update Data
        Pet Update(Pet petUpdate);

        //Delete Data
        Pet Delete(int id);
    }
}