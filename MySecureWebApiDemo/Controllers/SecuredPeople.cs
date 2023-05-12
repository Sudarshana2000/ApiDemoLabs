using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySecureWebApiDemo.Models;

namespace MySecureWebApiDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecuredPeopleController : ControllerBase
    {
        private ILogger<SecuredPeopleController> _logger;

        public SecuredPeopleController(ILogger<SecuredPeopleController> logger)
        {
            _logger = logger;
        }


        // define the Route Path as endpoints not registered in Main()
        [HttpGet(Name = "GetSecuredPeople")]     
        public IActionResult Get()
        {
            Person[] persons = new[]
            {
                new Person { Name = "Employee 1", Age = 20 },
                new Person { Name = "Employee 2", Age = 27, Gender = Gender.Male },
                new Person { Name = "Employee 3", Age = 32, Gender = Gender.Female },
                new Person { Name = "Employee 4", Age = 46, Gender = Gender.Male },
                new Person { Name = "Employee 5", Age = 18, Gender = Gender.Female }
            };

            _logger.LogInformation("extracting all employees");

            return Ok(persons);
        }
    }
}
