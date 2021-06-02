using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.TeamManagement.Database.Schema
{
    public class Internal
    {
        public int InternalId { get; set; }
        public int PersonId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Value { get; set; }

        public Person Person { get; set; }
    }
}
