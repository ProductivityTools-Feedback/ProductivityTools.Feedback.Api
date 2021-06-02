using System;
using System.Collections.Generic;
using System.Text;

namespace ProductivityTools.TeamManagement.Database.Schema
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public int PersonId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Value { get; set; }
        public string ReFeedback { get; set; }

        public Person Person { get; set; }
    }
}
