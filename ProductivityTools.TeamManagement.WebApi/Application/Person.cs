using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductivityTools.TeamManagement.WebApi.Application
{
    public class Person
    {
        private readonly WorkTimeDetails WorkTimeDetails;

        public string FirstName
        {
            get
            {
                return this.WorkTimeDetails.FirstName;
            }
        }
        public string Lastname
        {
            get
            {
                return this.WorkTimeDetails.LastName;
            }
        }
        public string Initials
        {
            get
            {
                return this.WorkTimeDetails.Initials;
            }
        }

        public Person(WorkTimeDetails workTimeDetails)
        {
            this.WorkTimeDetails = workTimeDetails;
        }
    }
}
