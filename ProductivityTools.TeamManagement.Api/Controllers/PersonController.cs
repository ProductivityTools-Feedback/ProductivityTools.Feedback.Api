using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.TeamManagement.Database;
using ProductivityTools.TeamManagement.Database.Schema;

namespace ProductivityTools.TeamManagement.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public TeamManagmentContext DbContext;

        public PersonController(TeamManagmentContext context)
        {
            this.DbContext = context;
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult Add( Person p)
        {
            var person = new Database.Schema.Person();
            person.FirstName = p.FirstName;
            person.LastName = p.LastName;
            person.Initials = p.Initials;
            person.Category = p.Category; 
            this.DbContext.Person.Add(person);
            this.DbContext.SaveChanges();
            return Ok(person);
        }
    }
}
