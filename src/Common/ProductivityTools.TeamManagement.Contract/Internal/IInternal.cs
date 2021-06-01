using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamFeedback.Contract.Internal
{
    [ServiceContract]
    public interface IInternal
    {
        [OperationContract]
        void SaveInternalInformation(List<string> initials, string value);

        [OperationContract]
        List<PersonInternalInformation> GetInternalInformation(List<string> initials);
    }
}
