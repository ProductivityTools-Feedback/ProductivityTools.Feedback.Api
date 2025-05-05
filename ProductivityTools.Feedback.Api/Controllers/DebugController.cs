using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductivityTools.Feedback.Database;
using System;
using System.Linq;

namespace ProductivityTools.Feedback.Api.Controllers
{
    [Route("api/[controller]")]

    public class DebugController : Controller
    {
        private readonly TeamManagmentContext TripContext;

        public DebugController(TeamManagmentContext context)
        {
            this.TripContext = context;
        }

        [HttpGet]
        [Route("Date")]
        public string Date()
        {
            return DateTime.Now.ToString();
        }

        [HttpGet]
        [Route("AppName")]
        public string AppName()
        {
            return "PTFeedback";
        }

        [HttpGet]
        [Route("Hello")]
        public string Hello(string name)
        {
            return string.Concat($"Hello {name.ToString()} Current date:{DateTime.Now}");
        }

        [HttpGet]
        [Route("ServerName")]
        public string ServerName()
        {
            string server = this.TripContext.Database.SqlQuery<string>($"select @@SERVERNAME as value").Single();
            return server;
        }
    }
}
