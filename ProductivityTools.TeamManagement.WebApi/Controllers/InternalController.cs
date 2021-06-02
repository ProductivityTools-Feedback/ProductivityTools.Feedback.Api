using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.TeamManagement.WebApi.Application;

namespace ProductivityTools.TeamManagement.WebApi.Controllers
{
    public class InternalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<PersonInternalInformation> GetInternalInformation(List<string> initials)
        {
            var people = Helpers.GetPerson(initials);

            List<PersonInternalInformation> personInternalInformation = new List<PersonInternalInformation>();
            foreach (var person in people)
            {
                var internalInformation = (from f in DbContext.Internal
                                           where f.Person.Initials == person.Initials
                                           select new Internal() { Date = f.CreatedDate, Value = f.Value }).ToList();
                personInternalInformation.Add(new PersonInternalInformation { FirstName = person.FirstName, LastName = person.Lastname, InternalInformation = internalInformation });

            }

            return personInternalInformation;
        }

        public void SaveInternalInformation(List<string> initials, string value)
        {
            var people = GetPerson(initials);
            foreach (var person in people)
            {
                var internalInformation = new PSTeamManagement.DB.Internal();
                internalInformation.CreatedDate = TimeTools.Now;
                internalInformation.Value = value;
                internalInformation.Person = person;
                this.DbContext.Internal.Add(internalInformation);
            }

            this.DbContext.SaveChanges();
        }
    }
}