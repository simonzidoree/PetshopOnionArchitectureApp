using System.Collections.Generic;
using Petshop.Core.Entities;

namespace Petshop.Core.ApplicationService
{
    public interface IOwnerService
    {
        //New Pet
        Owner NewOwner(string name);

        //Create
        Owner CreateOwner(Owner owner);

        //Read
        Owner FindOwnerById(int id);

        Owner FindOwnerByIdIncludePets(int id);

        List<Owner> GetAllOwners();

        //Update
        Owner UpdateOwner(int id, Owner ownerUpdate);

        //Delete
        Owner DeleteOwner(int id);
    }
}