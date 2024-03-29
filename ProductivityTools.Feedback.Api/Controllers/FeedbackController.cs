﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.Feedback.Contract.Feedback;
using ProductivityTools.Feedback.Database;
using ProductivityTools.Feedback.WebApi.Application;

namespace ProductivityTools.Feedback.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedbackController : Controller
    {
        TeamManagmentContext DbContext;

        public FeedbackController(TeamManagmentContext context)
        {
            this.DbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("GetFeedback")]
        public List<PersonFeedback> GetFeedback(List<string> initials)
        {
            var people = Helpers.GetPerson(DbContext,initials);

            List<PersonFeedback> personFeedbacks = new List<PersonFeedback>();
            foreach (var person in people)
            {
                var feedbacks = (from f in DbContext.Feedback
                                 where f.Person.Initials == person.Initials
                                 select new Contract.Feedback.Feedback() { Date = f.CreatedDate, Value = f.Value }).ToList();
                personFeedbacks.Add(new PersonFeedback { FirstName = person.FirstName, LastName = person.FirstName, Feedback = feedbacks });

            }

            return personFeedbacks;
        }

        [HttpPost]
        [Authorize]
        [Route("SaveFeedback")]
        public void SaveFeedback(SaveFeedback input)
        {
            var people = Helpers.GetPerson(DbContext,input.Initials);
            foreach (var person in people)
            {
                var newFeedback = new Database.Schema.Feedback();
                newFeedback.CreatedDate = TimeTools.Now;
                newFeedback.Value = input.Value;
                newFeedback.Person = person;
                this.DbContext.Feedback.Add(newFeedback);
            }

            this.DbContext.SaveChanges();
        }
    }
}