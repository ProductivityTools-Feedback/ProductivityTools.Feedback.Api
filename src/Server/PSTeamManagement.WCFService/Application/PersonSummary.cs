using PSTeamManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.WCFService.Application
{
    class PersonSummary
    {
        List<WorkTimeDetails> PersonRecords;
        Dictionary Dictionary;

        Person person;
        public Person Person
        {
            get
            {
                if (person == null)
                {
                    var personRecord = PersonRecords.First();
                    person = new Person(personRecord);
                }
                return person;
            }
        }

        List<DaySummary> daySummaryList;
        public List<DaySummary> DaySummaryList
        {
            get
            {
                if (daySummaryList == null)
                {
                    daySummaryList = new List<DaySummary>();
                    List<DateTime?> days = PersonRecords.GroupBy(x => x.Day).Select(x => x.Key).ToList();
                    foreach (var day in days)
                    {
                        var daySummary = new DaySummary(this.PersonRecords, this.Dictionary, day.Value);
                        daySummaryList.Add(daySummary);
                    }
                }
                return daySummaryList;
            }
        }

        public PersonSummary(List<WorkTimeDetails> personRecords)
        {
            this.PersonRecords = personRecords;
            this.Dictionary = new Dictionary();
        }
    }
}
