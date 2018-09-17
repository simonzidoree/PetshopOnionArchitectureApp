using System.Collections.Generic;

namespace Petshop.Core.Entities
{
    public class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}