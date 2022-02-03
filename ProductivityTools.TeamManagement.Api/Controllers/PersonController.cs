using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.TeamManagement.Database;
using ProductivityTools.TeamManagement.Database.Schema;

namespace ProductivityTools.TeamManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public TeamManagmentContext DbContext;

        public PersonController(TeamManagmentContext context)
        {
            this.DbContext = context;
        }


        public IActionResult Add(string firstName, string lastName, string initials, string category)
        {
            Person person = new Person();
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Initials = initials;
            person.Category = category; 
            this.DbContext.Person.Add(person);
            this.DbContext.SaveChanges();
            return Ok(person);
        }
    }
}
