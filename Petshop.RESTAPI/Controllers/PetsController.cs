using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Petshop.Core.ApplicationService;
using Petshop.Core.Entities;

namespace Petshop.RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/pets/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var pet = _petService.FindPetById(id);

            if (pet == null)
            {
                return BadRequest($"There is no Pet with the ID: {id}");
            }

            return pet;
        }

        // POST api/pets
        [HttpPost]
        public ActionResult<Pet> Post([FromBody] Pet pet)
        {
            if (pet.Name == null || pet.Type == null)
            {
                return BadRequest("You fucked up");
            }

            return _petService.CreatePet(pet);
        }

        // PUT api/pets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Pet pet)
        {
            _petService.UpdatePet(id, pet);
        }

        // DELETE api/pets/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _petService.DeletePet(id);
        }
    }
}