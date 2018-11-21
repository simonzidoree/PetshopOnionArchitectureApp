using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petshop.Core.ApplicationService;
using Petshop.Core.Entities;

namespace Petshop.RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [Authorize]
        // GET api/owners
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            return Ok(_ownerService.GetAllOwners());
        }

        [Authorize]
        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            var owner = _ownerService.FindOwnerByIdIncludePets(id);

            if (owner == null)
            {
                return BadRequest($"There is no Owner with the ID: {id}");
            }

            return Ok(owner);
        }

        [Authorize(Roles = "Administrator")]
        // POST api/owners
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            if (owner.FirstName == null || owner.LastName == null)
            {
                return BadRequest("The Owner has to have a FirstName and LastName!");
            }

            return Ok(_ownerService.CreateOwner(owner));
        }

        [Authorize(Roles = "Administrator")]
        // PUT api/owners/5
        [HttpPut("{id}")]
        public ActionResult<Owner> Put(int id, [FromBody] Owner owner)
        {
            if (id < 1 || id != owner.ID)
            {
                return BadRequest("Parameter Id and owner ID must be the same");
            }

            return Ok(_ownerService.UpdateOwner(id, owner));
        }

        [Authorize(Roles = "Administrator")]
        // DELETE api/owners/5
        [HttpDelete("{id}")]
        public ActionResult<Owner> Delete(int id)
        {
            return Ok(_ownerService.DeleteOwner(id));
        }
    }
}