using System.Collections.Generic;
using Petshop.Core.Entities;

namespace Petshop.Core.DomainService
{
    public interface IOwnerRepository
    {
        //Create Data
        Owner Create(Owner owner);

        //Read Data
        Owner ReadByID(int id);
        IEnumerable<Owner> ReadAllOwners();

        //Update Data
        Owner Update(Owner ownerUpdate);

        //Delete Data
        Owner Delete(int id);
    }
}