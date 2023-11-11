using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Feedback.Database;
using ProductivityTools.Feedback.Database.Schema;
using System.Collections.Generic;
using System.Linq;

namespace ProductivityTools.Feedback.Api.Controllers
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

        [HttpPost]
        [Route("GetList")]
        public List<Person> GetList()
        {
            List<Person> r = this.DbContext.Person.Select(x => new Person { FirstName = x.FirstName, LastName = x.LastName, Initials = x.Initials, Category = x.Category }).ToList();
            
            return r;
        }
    }
}
