using PSTeamManagement.Cmdlet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.InternalInformation.Commands
{
    public class Set : InternalBaseCommand<SetInternal>
    {
        protected override bool Condition => this.Cmdlet.Initials.AnyPersonInitial() && !string.IsNullOrEmpty(this.Cmdlet.Value);

        public Set(SetInternal cmdlet) : base(cmdlet) { }

        protected override void Invoke()
        {
            this.Client.SaveInternalInformation(this.Cmdlet.Initials.SplitToList(), this.Cmdlet.Value);
            this.CloseClient();
        }
    }
}
