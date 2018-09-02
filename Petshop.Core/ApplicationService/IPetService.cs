using Petshop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Petshop.Core.ApplicationService
{
    public interface IPetService
    {
        List<Pet> GetPets();
    }
}
