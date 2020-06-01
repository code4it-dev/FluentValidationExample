using FluentValidation;
using FluentValidationExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IValidator<User> validator;

        public RegistrationController(IValidator<User> validator)
        {
            this.validator = validator;
        }

        [HttpPost]
        public IActionResult Register(User newUser)
        {
            //var validationResult = validator.Validate(newUser);

            //if (!validationResult.IsValid)
            //{
            //    return BadRequest(validationResult.Errors.First().ErrorMessage);
            //}

            return Ok();
        }
    }
}
