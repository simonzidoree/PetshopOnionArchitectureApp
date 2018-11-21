using System.Collections.Generic;
using Petshop.Core.Entities;

namespace Petshop.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
    }
}