using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductivityTools.TeamManagement.Contract.Feedback;
using ProductivityTools.TeamManagement.Database;
using ProductivityTools.TeamManagement.WebApi.Application;

namespace ProductivityTools.TeamManagement.WebApi.Controllers
{
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

        public List<PersonFeedback> GetFeedback(List<string> initials)
        {
            var people = Helpers.GetPerson(DbContext,initials);

            List<PersonFeedback> personFeedbacks = new List<PersonFeedback>();
            foreach (var person in people)
            {
                var feedbacks = (from f in DbContext.Feedback
                                 where f.Person.Initials == person.Initials
                                 select new Feedback() { Date = f.CreatedDate, Value = f.Value }).ToList();
                personFeedbacks.Add(new PersonFeedback { FirstName = person.FirstName, LastName = person.FirstName, Feedback = feedbacks });

            }

            return personFeedbacks;
        }

        public void SaveFeedback(List<string> initials, string value)
        {
            var people = Helpers.GetPerson(DbContext,initials);
            foreach (var person in people)
            {
                var newFeedback = new Database.Schema.Feedback();
                newFeedback.CreatedDate = TimeTools.Now;
                newFeedback.Value = value;
                newFeedback.Person = person;
                this.DbContext.Feedback.Add(newFeedback);
            }

            this.DbContext.SaveChanges();
        }
    }
}