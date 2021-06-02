using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductivityTools.TeamManagement.Contract.Feedback
{
    [ServiceContract]
    public interface IFeedback
    {
        [OperationContract]
        void SaveFeedback(List<string> initials, string value);

        [OperationContract]
        List<PersonFeedback> GetFeedback(List<string> initials);
    }
}
