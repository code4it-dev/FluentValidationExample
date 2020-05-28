using FluentValidationExample.Models;
using FluentValidationExample.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FluentValidationExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly UserValidator validator;

        public RegistrationController()
        {
            validator = new UserValidator();
        }
        [HttpPost]
        public IActionResult Register(User newUser)
        {
            var validationResult = validator.Validate(newUser);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.First().ErrorMessage);
            }

            return Ok();
        }
    }
}
