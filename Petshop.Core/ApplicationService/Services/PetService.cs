using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Petshop.Core.DomainService;
using Petshop.Core.Entities;

namespace Petshop.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<Pet> GetPets()
        {
            var listPets = _petRepository.ReadPets().ToList();
            return listPets;
        }
    }
}
