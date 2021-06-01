using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.WCFService
{
    public static class TimeTools
    {
        public static DateTime SubtrackMinutes(this DateTime dt, int minutes)
        {
            return dt.AddMinutes(-1 * minutes);
        }

        public static DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

    }
}
