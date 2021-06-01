using PSTeamFeedback.Contract.Internal;
using PSTeamManagement.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.WCFService
{
    public partial class TeamManagement : IInternal
    {
        public List<PersonInternalInformation> GetInternalInformation(List<string> initials)
        {
            var people = GetPerson(initials);

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
