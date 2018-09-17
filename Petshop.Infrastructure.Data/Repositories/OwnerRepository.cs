using System.Collections.Generic;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entities;

namespace Petshop.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner Create(Owner owner)
        {
            owner.ID = FakeDB.OwnerID++;
            var owners = FakeDB.Owners.ToList();
            owners.Add(owner);
            FakeDB.Owners = owners;
            return owner;
        }

        public Owner ReadByID(int id)
        {
            return FakeDB.Owners
                .Select(o => new Owner
                {
                    ID = o.ID,
                    Name = o.Name
                })
                .FirstOrDefault(o => o.ID == id);
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return FakeDB.Owners;
        }

        public Owner Update(Owner ownerUpdate)
        {
            var ownerFromDB = ReadByID(ownerUpdate.ID);
            if (ownerFromDB != null)
            {
                ownerFromDB.Name = ownerUpdate.Name;
                return ownerFromDB;
            }

            return null;
        }

        public Owner Delete(int id)
        {
            var owners = FakeDB.Owners.ToList();
            var ownerFoundID = ReadByID(id);

            if (ownerFoundID != null)
            {
                owners.Remove(ownerFoundID);
                FakeDB.Owners = owners;
                return ownerFoundID;
            }

            return null;
        }
    }
}