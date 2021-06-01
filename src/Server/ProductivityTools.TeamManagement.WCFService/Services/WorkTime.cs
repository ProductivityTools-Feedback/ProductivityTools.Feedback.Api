using PSTeamManagement.DB;
using PSTeamManagement.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSTeamFeedback.Contract.WorkTime;
using AutoMapper;

namespace PSTeamManagement.WCFService
{
    public partial class TeamManagement : IWorkTime
    {
        private DictValue GetEventType(string key)
        {
            var dicvalue = DbContext.DictValue.Where(x => x.Dictionary.Name == DictionaryEventKey && x.Key == key).Single(); ;
            return dicvalue;
        }

        public void PersonAlreadyIn(List<string> initials, int minutesAgo)
        {
            SetNewRecord(initials, minutesAgo, StatusType.AlreadyIn); ;
        }

        public void PersonAlreadyOut(List<string> initials, int minutesAgo)
        {
            SetNewRecord(initials, minutesAgo, StatusType.AlreadyOut);
        }

        public void PersonIn(List<string> initials, int minutesAgo)
        {
            SetNewRecord(initials, minutesAgo, StatusType.In);
        }

        public void PersonOut(List<string> initials, int minutesAgo)
        {
            SetNewRecord(initials, minutesAgo, StatusType.Out);
        }

        public void BreakStart(List<string> initials, int minutesAgo)
        {
            SetNewRecord(initials, minutesAgo, StatusType.BreakStart);
        }

        public void BreakEnd(List<string> initials, int minutesAgo)
        {
            SetNewRecord(initials, minutesAgo, StatusType.BreakEnd);
        }

        public void StillIn(List<string> initials, int minutesAgo)
        {
            SetNewRecord(initials, minutesAgo, StatusType.StillIn);
        }

        private void SetNewRecord(List<string> initials, int minutesAgo, StatusType statusType)
        {
            var personList = GetPerson(initials);
            var dictValue = GetEventType(statusType.ToString());
            var datetimeCreated = TimeTools.Now.SubtrackMinutes(minutesAgo);

            foreach (var person in personList)
            {
                DbContext.WorkTime.Add(new WorkTime() { Person = person, CreatedDate = datetimeCreated, DictValue = dictValue });
            }
            DbContext.SaveChanges();
        }

        public void Comment(List<string> initials, string comment)
        {
            var personList = GetPerson(initials);

            var datetimeCreated = TimeTools.Now;
            foreach (var person in personList)
            {
                DbContext.WorkTimeComment.Add(new WorkTimeComment() { Person = person, CreatedDate = datetimeCreated, Comment = comment });
            }
            DbContext.SaveChanges();
        }

        public void Lunch(List<string> initials)
        {
            var personList = GetPerson(initials);
            var datetimeCreated = TimeTools.Now;
            foreach (var person in personList)
            {
                DbContext.WorkLunch.Add(new WorkLunch() { Person = person, CreatedDate = datetimeCreated, Lunch = true });
            }
            DbContext.SaveChanges();
        }


        public List<PersonSummary> GetWorkTime(List<string> initials)
        {
            

            List<WorkTimeDetails> workTimeDetialsForGroup = DbContext.WorkTimeDetails.Where(x => initials.Contains(x.Initials)).ToList();

            var appPersonSummary = new List<Application.PersonSummary>();
            foreach (var initial in initials)
            {
                //PersonSummary summary = new PersonSummary();

                var personRecords = workTimeDetialsForGroup.Where(x => x.Initials == initial).ToList();
                var pr = new Application.PersonSummary(personRecords);
                appPersonSummary.Add(pr);

               
                //summary.Person = new PSTeamFeedback.Contract.WorkTime.Person();

                //summary.Person.FirstName = personRecord.FirstName;
                //summary.Person.LastName = personRecord.LastName;
                //summary.Person.Initials = personRecord.Initials;

                //summary.DaySummary = GetPersonSummaryRecord(personRecords);

                //result.Add(summary);
            }

            List<PersonSummary> result = new List<PersonSummary>();

            
           // var xx=Mapper.Map<Application.Person, PSTeamFeedback.Contract.WorkTime.Person>(appPersonSummary[0].)
            var dest = Mapper.Map<List<Application.PersonSummary>, List<PersonSummary>>(appPersonSummary);

            return dest;
        }

 
        private List<DaySummary> GetPersonSummaryRecord(IEnumerable<WorkTimeDetails> personRecords)
        {
            var dictionary = new Dictionary();

            List<DaySummary> daySummaryList = new List<DaySummary>();

            List<DateTime?> days = personRecords.GroupBy(x => x.Day).Select(x => x.Key).ToList();
            foreach (var day in days)
            {
                var daySummary = new DaySummary();
                daySummary.Date = day.Value;
                daySummaryList.Add(daySummary);
                //daySummary.In = personRecords.SingleOrDefault(x => x.Day == day && x.EventTypeId == @in)?.CreatedDate;
              //  daySummary.Out = personRecords.SingleOrDefault(x => x.Day == day && x.EventTypeId == @out)?.CreatedDate;
               // daySummary.AlreadyIn = personRecords.SingleOrDefault(x => x.Day == day && x.EventTypeId == @alreadyIn)?.CreatedDate;
               // daySummary.AlreadyOut = personRecords.SingleOrDefault(x => x.Day == day && x.EventTypeId == @alreadyOut)?.CreatedDate;
                //daySummary.StillIn = personRecords.SingleOrDefault(x => x.Day == day && x.EventTypeId == @stillIn)?.CreatedDate;

                //var breakRecords = personRecords
                //    .Where(x => x.Day == day && (x.EventTypeId == breakStart || x.EventTypeId == breakEnd))
                //    .OrderByDescending(x => x.CreatedDate).ToList();

                //TimeSpan summaryOfBreaks = new TimeSpan();
                //for (int i = 0; i < breakRecords.Count; i = i + 2)
                //{
                //    if (breakRecords[i].EventTypeId != breakEnd) throw new Exception("Missing BreakEnd");
                //    if (breakRecords[i + 1].EventTypeId != breakStart) throw new Exception("Missing BreakStart");
                //    summaryOfBreaks += breakRecords[i].CreatedDate.Subtract(breakRecords[i + 1].CreatedDate);
                //}
                //daySummary.BreaksTime = summaryOfBreaks;


            }

            
            //daySummary.Start=personRecords.SingleOrDefault
            return daySummaryList;
        }
    }
}
