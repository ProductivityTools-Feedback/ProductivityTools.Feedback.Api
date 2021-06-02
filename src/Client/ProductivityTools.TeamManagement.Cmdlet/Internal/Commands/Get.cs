using PSTeamManagement.Cmdlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.InternalInformation.Commands
{
    public class Get : InternalBaseCommand<GetInternal>
    {
        protected override bool Condition => this.Cmdlet.Initials.AnyPersonInitial();

        public Get(GetInternal cmdlet) : base(cmdlet) { }

        protected override void Invoke()
        {
            //this.Client.GetInternalInformation(PersonInitialList);

            var perfonFeedbackList = this.Client.GetInternalInformation(this.Cmdlet.Initials.SplitToList());
            this.CloseClient();

            foreach (var person in perfonFeedbackList)
            {
                Console.WriteLine($"[{person.FirstName} {person.LastName}]");

                foreach (var item in person.InternalInformation)
                {
                    Console.WriteLine($"[{item.Date}]");
                    Console.WriteLine($"{item.Value}");
                    Console.WriteLine("");
                }
            }
        }
    }
}
