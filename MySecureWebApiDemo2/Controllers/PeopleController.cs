using Microsoft.AspNetCore.Mvc;
using MySecureWebApiDemo2.Models;

namespace MySecureWebApiDemo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private ILogger<PeopleController> _logger;

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }


        // define the Route Path as endpoints not registered in Main()
        [HttpGet(Name = "GetPeople")]     
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
