using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskWebApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetContentAsync()
        {
            var myTask = new HttpClient().GetStringAsync("https://www.google.com");
            // some business code without non async
            var data = await myTask;
            return Ok(data);
        }
    }
}
