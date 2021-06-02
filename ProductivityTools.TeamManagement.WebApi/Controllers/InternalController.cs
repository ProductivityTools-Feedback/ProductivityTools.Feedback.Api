﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.TeamManagement.Database;
using ProductivityTools.TeamManagement.WebApi.Application;
using PSTeamFeedback.Contract.Internal;

namespace ProductivityTools.TeamManagement.WebApi.Controllers
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
        [Route("SaveInternalInformation")]
        public void SaveInternalInformation(List<string> initials, string value)
        {
            var people = Helpers.GetPerson(DbContext, initials);
            foreach (var person in people)
            {
                var internalInformation = new Database.Schema.Internal();
                internalInformation.CreatedDate = TimeTools.Now;
                internalInformation.Value = value;
                internalInformation.Person = person;
                this.DbContext.Internal.Add(internalInformation);
            }

            this.DbContext.SaveChanges();
        }
    }
}