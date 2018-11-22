using System.Collections.Generic;
using Petshop.Core.DomainService;
using Petshop.Core.Entities;

namespace Petshop.Infrastructure.Data.RepositoriesSQL
{
    public class UserRepository: IUserRepository
    {
        private readonly PetshopContext _ctx;

        public UserRepository(PetshopContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<User> GetAll()
        {
            return _ctx.Users;
        }

        public User Create(User t)
        {
            var user = _ctx.Users.Add(t).Entity;
            _ctx.SaveChanges();
            return user;
        }
    }
}