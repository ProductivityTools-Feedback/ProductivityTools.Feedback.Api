using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Feedback.Contract.Internal;
using ProductivityTools.Feedback.Database;
using ProductivityTools.Feedback.WebApi.Application;

namespace ProductivityTools.Feedback.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InternalController : Controller
    {
        TeamManagmentContext DbContext;

        public InternalController(TeamManagmentContext context)
        {
            this.DbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("GetInternalInformation")]
        public List<PersonInternalInformation> GetInternalInformation(List<string> initials)
        {
            var people = Helpers.GetPerson(DbContext, initials);

            List<PersonInternalInformation> personInternalInformation = new List<PersonInternalInformation>();
            foreach (var person in people)
            {
                var internalInformation = (from f in DbContext.Internal
                                           where f.Person.Initials == person.Initials
                                           select new Internal() { Date = f.CreatedDate, Value = f.Value }).ToList();
                personInternalInformation.Add(new PersonInternalInformation { FirstName = person.FirstName, LastName = person.LastName, InternalInformation = internalInformation });

            }

            return personInternalInformation;
        }

        [HttpPost]
        [Authorize]
        [Route("SaveInternalInformation")]
        public void SaveInternalInformation(SaveInternalInformation input)
        {
            var people = Helpers.GetPerson(DbContext, input.Initials);
            foreach (var person in people)
            {
                var internalInformation = new Database.Schema.Internal();
                internalInformation.CreatedDate = TimeTools.Now;
                internalInformation.Value = input.Value;
                internalInformation.Person = person;
                this.DbContext.Internal.Add(internalInformation);
            }

            this.DbContext.SaveChanges();
        }
    }
}