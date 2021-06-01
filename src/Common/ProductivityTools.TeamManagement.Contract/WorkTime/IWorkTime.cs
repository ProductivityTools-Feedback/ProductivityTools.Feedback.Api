using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamFeedback.Contract.WorkTime
{
    [ServiceContract]
    public interface IWorkTime
    {
        [OperationContract]
        void PersonIn(List<string> intials, int minutesAgo);

        [OperationContract]
        void PersonOut(List<string> initials, int minutesAgo);

        [OperationContract]
        void PersonAlreadyIn(List<string> initials, int minutesAgo);

        [OperationContract]
        void PersonAlreadyOut(List<string> initials, int minutesAgo);

        [OperationContract]
        void BreakStart(List<string> initials, int minutesAgo);

        [OperationContract]
        void BreakEnd(List<string> initials, int minutesAgo);

        [OperationContract]
        void StillIn(List<string> initials, int minutesAgo);

        [OperationContract]
        void Comment(List<string> initials, string comment);

        [OperationContract]
        void Lunch(List<string> initials);

        [OperationContract]
        List<PersonSummary> GetWorkTime(List<string> initials);
    }
}
