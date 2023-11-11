using ProductivityTools.Feedback.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTools.Feedback.WebApi.Application
{
    public static class Helpers
    {
        public static  List<Database.Schema.Person> GetPerson(TeamManagmentContext DbContext, List<string> initials)
        {
            var personList = from person in DbContext.Person
                             where initials.Contains(person.Initials)
                             select person;
            return personList.ToList();
        }
    }
}
