using ProductivityTools.PSCmdlet;
using PSTeamManagement.Cmdlet;
using PSTeamManagment.Cmdlet.Feedback.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.InternalInformation.Commands
{
    [Cmdlet(VerbsCommon.Get, "Internal")]
    [Description("Get-Internal returns internal (which shouldn't be shared) information about chosen people")]
    public class GetInternal : PSCmdletPT
    {
        public GetInternal()
        {
            Helpers.Init();
            this.AddCommand(new Get(this));
        }

        [Parameter(Position =0)]
        [Description("Initials splited with space")]
        public string Initials { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
