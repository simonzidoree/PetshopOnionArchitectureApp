using System.Collections.Generic;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entities;

namespace Petshop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public Owner NewOwner(string name)
        {
            var owner = new Owner
            {
                Name = name
            };

            return owner;
        }

        public Owner CreateOwner(Owner owner)
        {
            return _ownerRepository.Create(owner);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.ReadByID(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.ReadAllOwners().ToList();
        }

        public Owner UpdateOwner(int id, Owner ownerUpdate)
        {
            var owner = FindOwnerById(id);
            owner.Name = ownerUpdate.Name;
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.Delete(id);
        }
    }
}