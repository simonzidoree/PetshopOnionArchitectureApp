using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Petshop.Core.DomainService;
using Petshop.Core.Entities;

namespace Petshop.Infrastructure.Data.RepositoriesSQL
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PetshopContext _ctx;

        public OwnerRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public Owner Create(Owner owner)
        {
            var ownerFromDB = _ctx.Owners.Add(owner).Entity;
            _ctx.SaveChanges();
            return ownerFromDB;
        }

        public Owner ReadByID(int id)
        {
            return _ctx.Owners.FirstOrDefault(o => o.ID == id);
        }

        public Owner ReadByIDIncludePets(int id)
        {
            return _ctx.Owners
                .Include(o => o.Pets)
                .FirstOrDefault(o => o.ID == id);
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _ctx.Owners;
        }

        public Owner Update(Owner ownerUpdate)
        {
            throw new NotImplementedException();
        }

        public Owner Delete(int id)
        {
            var ownerRemoved = _ctx.Remove(new Owner {ID = id}).Entity;
            _ctx.SaveChanges();
            return ownerRemoved;
        }
    }
}