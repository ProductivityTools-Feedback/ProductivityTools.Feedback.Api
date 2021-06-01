using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamFeedback.Contract.WorkTime
{
    public class PersonSummary
    {
        public PersonSummary()
        {
            this.DaySummaryList = new List<DaySummary>();
        }
        public Person Person { get; set; }
        public List<DaySummary> DaySummaryList { get; set; }
    }
}
