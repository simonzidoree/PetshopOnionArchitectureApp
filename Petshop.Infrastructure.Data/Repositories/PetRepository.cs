using Petshop.Core.DomainService;
using Petshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Infrastructure.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        public IEnumerable<Pet> ReadPets()
        {
            return FakeDB.Pets;
        }
    }
}
