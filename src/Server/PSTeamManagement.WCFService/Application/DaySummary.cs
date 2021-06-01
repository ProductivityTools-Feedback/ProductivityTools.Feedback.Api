using PSTeamManagement.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.WCFService.Application
{
    class DaySummary
    {

        public DaySummary(List<WorkTimeDetails> personRec, Dictionary dictionary, DateTime day)
        {
            this.personRecords = personRec;
            this.Dictionary = dictionary;
            this.Date = day;
            this.Errors = new List<string>();
        }

        private List<WorkTimeDetails> personRecords { get; set; }
        private Dictionary Dictionary;
        public readonly DateTime? Date;

        public DateTime? In
        {
            get
            {
                int @in = GetId(Dictionary, StatusType.In);
                return personRecords.SingleOrDefault(x => x.Day == Date && x.EventTypeId == @in)?.CreatedDate;
            }
        }

        public DateTime? AlreadyIn
        {
            get
            {
                int @alreadyIn = GetId(Dictionary, StatusType.AlreadyIn);
                return personRecords.SingleOrDefault(x => x.Day == Date && x.EventTypeId == @alreadyIn)?.CreatedDate;
            }
        }

        public DateTime? Out
        {
            get
            {

                int @out = GetId(Dictionary, StatusType.Out);
                return personRecords.SingleOrDefault(x => x.Day == Date && x.EventTypeId == @out)?.CreatedDate;
            }
        }

        public DateTime? AlreadyOut
        {
            get
            {
                int @alreadyOut = GetId(Dictionary, StatusType.AlreadyOut);
                return personRecords.SingleOrDefault(x => x.Day == Date && x.EventTypeId == @alreadyOut)?.CreatedDate;
            }
        }

        public DateTime? StillIn
        {
            get
            {
                int @stillIn = GetId(Dictionary, StatusType.StillIn);
                return personRecords.SingleOrDefault(x => x.Day == Date && x.EventTypeId == @stillIn)?.CreatedDate;
            }
        }

        public TimeSpan BreaksTime
        {
            get
            {
                int breakStart = GetId(Dictionary, StatusType.BreakStart);
                int breakEnd = GetId(Dictionary, StatusType.BreakEnd);

                var breakRecords = personRecords
                   .Where(x => x.Day == Date && (x.EventTypeId == breakStart || x.EventTypeId == breakEnd))
                   .OrderByDescending(x => x.CreatedDate).ToList();

                TimeSpan summaryOfBreaks = new TimeSpan();

                for (int i = 0; i < breakRecords.Count; i = i + 2)
                {
                    if (breakRecords[i].EventTypeId != breakEnd) { this.Errors.Add(ErrorMissingClosingBreak); continue; }
                    if(i==breakRecords.Count-1) { this.Errors.Add(ErrorMissingClosingBreak);continue; }

                    if (breakRecords[i + 1].EventTypeId != breakStart) { throw new Exception("Missing BreakStart"); }
                    summaryOfBreaks += breakRecords[i].CreatedDate.Subtract(breakRecords[i + 1].CreatedDate);
                }
                return summaryOfBreaks;
            }
        }

        private string ErrorMissingClosingBreak = "Missing the closing break";

        public List<String> Errors { get; set; }

        private int GetId(Dictionary dictionary, StatusType status)
        {
            int id = dictionary.GetDictValueIdByKey(DictionaryType.Event.ToString(), status.ToString());
            return id;
        }

        private DateTime? Start
        {
            get
            {
                var x = this.In ?? this.AlreadyIn;
                return x;
                //if (this.In.HasValue) return this.In.Value;
                //if (this.AlreadyIn.HasValue) return this.AlreadyIn.Value;
            }
        }

        private DateTime? End
        {
            get
            {
                var x = this.Out ?? this.AlreadyOut ?? this.StillIn;
                return x;
                //if (this.In.HasValue) return this.In.Value;
                //if (this.AlreadyIn.HasValue) return this.AlreadyIn.Value;
            }
        }

        public TimeSpan? InToOutTime
        {
            get
            {
                if (Start.HasValue)
                {
                    if (End.HasValue)
                    {
                        var x = this.End.Value.Subtract(this.Start.Value);
                        return x;
                    }
                    else
                    {
                        var x = TimeTools.Now.Subtract(this.Start.Value);
                        return x;
                    }
                }
                return null;
            }
        }

        public TimeSpan? Workingtime
        {
            get
            {
                if (InToOutTime == null)
                {
                    return null;
                }
                else
                {
                    var x = InToOutTime.Value.Subtract(BreaksTime);
                    return x;
                }
            }
        }

    }
}
