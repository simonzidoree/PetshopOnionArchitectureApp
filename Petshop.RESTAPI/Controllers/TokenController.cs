using Microsoft.AspNetCore.Mvc;
using Petshop.Core.ApplicationService;
using Petshop.Core.Entities;

namespace Petshop.RESTAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IUserService _Service;

        public TokenController(IUserService service)
        {
            _Service = service;
        }


        [HttpPost]
        public IActionResult Login([FromBody]LoginInput model)
        {
            var user = _Service.GetWhereUsername(model.Username);


            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!_Service.CheckCorrectPassword(user, model))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = _Service.GenerateToken(user)
            });
        }
    }
}