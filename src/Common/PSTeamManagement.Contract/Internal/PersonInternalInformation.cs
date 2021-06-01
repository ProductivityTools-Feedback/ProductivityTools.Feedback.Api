using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamFeedback.Contract.Internal
{
    public class PersonInternalInformation
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Internal> InternalInformation { get; set; }
    }
}
