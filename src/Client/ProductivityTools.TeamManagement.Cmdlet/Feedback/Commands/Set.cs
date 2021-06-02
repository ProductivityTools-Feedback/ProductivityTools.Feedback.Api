using ProductivityTools.TeamManagement.Cmdlet.ClientCaller;
using PSTeamManagement.Cmdlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.Feedback.Commands
{
    public class Set : TeamManagmentCmdletBase<SetFeedback>
    {
        protected override bool Condition => this.Cmdlet.Initials.AnyPersonInitial() && !string.IsNullOrEmpty(this.Cmdlet.Value);

        public Set(SetFeedback cmdlet) : base(cmdlet) { }

        protected override void Invoke()
        {
            ApiClient.SaveFeedback(this.Cmdlet.Initials.SplitToList(), this.Cmdlet.Value); 
            //this.Client.SaveFeedback(this.Cmdlet.Initials.SplitToList(), this.Cmdlet.Value);
           // this.CloseClient();
        }
    }
}
