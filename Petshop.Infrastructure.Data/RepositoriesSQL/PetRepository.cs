using System;
using System.Collections.Generic;
using Petshop.Core.DomainService;
using Petshop.Core.Entities;

namespace Petshop.Infrastructure.Data.RepositoriesSQL
{
    public class PetRepository : IPetRepository
    {
        private readonly PetshopContext _ctx;

        public PetRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public Pet Create(Pet pet)
        {
            throw new NotImplementedException();
        }

        public Pet ReadByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadAllPets()
        {
            return _ctx.Pets;
        }

        public Pet Update(Pet petUpdate)
        {
            throw new NotImplementedException();
        }

        public Pet Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}