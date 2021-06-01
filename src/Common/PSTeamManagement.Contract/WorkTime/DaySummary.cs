using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamFeedback.Contract.WorkTime
{
    public class DaySummary
    {
        public DateTime Date { get; set; }
        public DateTime? In { get; set; }

        public DateTime? Out { get; set; }

        public DateTime? AlreadyIn { get; set; }

        public DateTime? StillIn { get; set; }

        public DateTime? AlreadyOut { get; set; }
        public TimeSpan BreaksTime { get; set; }

        public TimeSpan InToOutTime { get; set; }

        public TimeSpan Workingtime { get; set; }

        public List<String> Errors { get; set; }
    }
}
