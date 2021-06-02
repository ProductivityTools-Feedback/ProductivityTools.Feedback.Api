using ProductivityTools.SimpleHttpPostClient;
using ProductivityTools.TeamManagement.Contract.Feedback;
using System;
using System.Collections.Generic;

namespace ProductivityTools.TeamManagement.Cmdlet.ClientCaller
{


    public class ApiClient
    {
        private readonly HttpPostClient Client;

        public ApiClient()
        {
            this.Client = new HttpPostClient(true);
            this.Client.SetBaseUrl("https://localhost:44386");
        }

        public List<PersonFeedback> GetFeedback(List<string> initials)
        {
            var result = this.Client.PostAsync<List<PersonFeedback>>("Feedback", "GetFeedback", initials).Result;
            return result;
        }

    }
}
