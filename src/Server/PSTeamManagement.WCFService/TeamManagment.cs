using AutoMapper;
using PSTeamFeedback.Contract.WorkTime;
using PSTeamManagement.Configuration;
using PSTeamManagement.DB;
using PSTeamManagement.WCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.WCFService
{
    public partial class TeamManagement
    {

        static TeamManagement()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Application.PersonSummary, PersonSummary>();
                cfg.CreateMap<Application.Person, PSTeamFeedback.Contract.WorkTime.Person>();
                cfg.CreateMap<Application.DaySummary, DaySummary>();
            });
        }

        private const string DictionaryEventKey = "Event";

        TeamFeadbackEntities context;
        private TeamFeadbackEntities DbContext
        {
            get
            {
                if (context == null)
                {
                    context = new ContextFactory().CreateNewContext();
                }
                return context;
            }
        }

        private List<DB.Person> GetPerson(List<string> initials)
        {
            var personList = from person in DbContext.Person
                             where initials.Contains(person.Initials)
                             select person;
            return personList.ToList();
        }

     
    }
}
