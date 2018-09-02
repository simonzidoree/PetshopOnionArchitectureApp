using Petshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Core.DomainService
{
    public interface IPetRepository
    {
        IEnumerable<Pet> ReadPets();
    }
}
