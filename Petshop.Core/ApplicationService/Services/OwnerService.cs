using System.Collections.Generic;
using System.Linq;
using Petshop.Core.DomainService;
using Petshop.Core.Entities;

namespace Petshop.Core.ApplicationService.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPetRepository _petRepository;

        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepository = ownerRepository;
            _petRepository = petRepository;
        }

        public Owner NewOwner(string firstName, string lastName)
        {
            var owner = new Owner
            {
                FirstName = firstName,
                LastName = lastName
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

        public Owner FindOwnerByIdIncludePets(int id)
        {
            var owner = _ownerRepository.ReadByIDIncludePets(id);
            return owner;
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.ReadAllOwners().ToList();
        }

        public Owner UpdateOwner(int id, Owner ownerUpdate)
        {
            var owner = FindOwnerById(id);
            owner.FirstName = ownerUpdate.FirstName;
            owner.LastName = ownerUpdate.LastName;
            return _ownerRepository.Update(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.Delete(id);
        }
    }
}