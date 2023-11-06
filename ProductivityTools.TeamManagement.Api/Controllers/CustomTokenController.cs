using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProductivityTools.TeamManagement.Api.Controllers
{
    public class CustomTokenController : Controller
    {
        [HttpGet]
        [Route("Get")]
        public async Task<string> GetCmdletToken()
        {
            var uid = "cmdlet";
            string customToken = await FirebaseAuth.DefaultInstance.CreateCustomTokenAsync(uid);
            return customToken;
        }
    }
}
