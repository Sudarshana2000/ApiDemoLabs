using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MySecondApiController : ControllerBase
    {

        [HttpGet]
        [ActionName("GetData")]
        public IActionResult GetData()
        {
            var obj = new
            {
                Id = 10,
                Name = "First Employee",
                IsEnabled = true,
                DOB = DateTime.Now
            };

            return Ok(obj);
        }

    }
}
