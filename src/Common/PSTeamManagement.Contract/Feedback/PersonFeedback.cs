using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.Contract.Feedback
{
    public class PersonFeedback
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Feedback> Feedback { get; set; }
    }
}
