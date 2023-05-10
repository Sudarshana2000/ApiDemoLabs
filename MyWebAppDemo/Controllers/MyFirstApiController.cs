using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace MyWebAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyFirstApiController : ControllerBase
    {
        // https://localhost:xxxx/api/MyFirstApi
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new string[] { "hello", "world" });
        }
    }
}
