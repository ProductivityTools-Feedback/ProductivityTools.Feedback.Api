using ProductivityTools.SimpleHttpPostClient;
using ProductivityTools.TeamManagement.Contract.Feedback;
using PSTeamFeedback.Contract.Feedback;
using PSTeamFeedback.Contract.Internal;
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

        public void SaveFeedback(List<string> initials, string value)
        {
            var r = this.Client.PostAsync<object>("Feedback", "SaveFeedback", new SaveFeedback { Initials = initials, Value = value }).Result;
        }

        public List<PersonInternalInformation> GetInternalInformation(List<string> initials)
        {
            var result = this.Client.PostAsync<List<PersonInternalInformation>>("Internal", "GetInternalInformation", initials).Result;
            return result;
        }

        public void SaveInternalInformation(List<string> initials, string value)
        {
            var r = this.Client.PostAsync<object>("Internal", "SaveInternalInformation", new SaveInternalInformation { Initials = initials, Value = value }).Result;
        }
    }
}
