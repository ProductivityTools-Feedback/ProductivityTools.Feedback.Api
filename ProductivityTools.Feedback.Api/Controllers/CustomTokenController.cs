using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace ProductivityTools.Feedback.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomTokenController : Controller
    {
        private readonly IConfiguration configuration;

        public CustomTokenController(IConfiguration configuration)
        {
            this.configuration = configuration;

        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetCmdletToken(string user, string password)
        {
            var uid = "user";
            if (configuration[string.Format($"{user}Password")] == password)
            {
                string customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid);
                return Ok(customToken);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
